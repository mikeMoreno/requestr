﻿using Requestr.Lib;
using Requestr.Lib.Models;
using Requestr.PostmanImporter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Requestr.Forms
{
    public partial class RequestPanel : UserControl
    {
        private readonly HttpClient httpClient;
        private readonly CookieService cookieService;

        internal RequestPanel(Request request, CookieService cookieService)
        {
            InitializeComponent();

            var handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                AllowAutoRedirect = false,
                UseCookies = false, // For now, let's see what happens.
            };

            httpClient = new HttpClient(handler);

            this.cookieService = cookieService;

            comboMethod.SelectedItem = request.Method;
            textUrl.Text = request.Url;
        }

        private async void BtnSend_Click(object sender, EventArgs e)
        {
            var method = comboMethod.SelectedItem as string;
            var url = textUrl.Text;

            if (string.IsNullOrWhiteSpace(url))
            {
                return;
            }

            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
            httpClient.DefaultRequestHeaders.Add($"{Globals.ApplicationName}-Token", Guid.NewGuid().ToString());
            httpClient.DefaultRequestHeaders.Add("User-Agent", $"{Globals.ApplicationName}/{Globals.ApplicationVersion}");
            httpClient.DefaultRequestHeaders.Add("Accept", "*/*");
            httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");


            var cookies = await cookieService.GetCookiesAsync(url);

            var stopwatch = new Stopwatch();

            stopwatch.Start();

            using var response = await SendRequestAsync(method, url, cookies);

            stopwatch.Stop();

            if (response.Headers.TryGetValues("Set-Cookie", out var setCookies))
            {
                await cookieService.SetCookiesAsync(setCookies);
            }

            var responseBodyPanel = tabBody.Controls.OfType<ResponseBodyPanel>().Single(c => c.Name == "responseBodyPanel");

            var responseContent = await response.Content.ReadAsStringAsync();

            lblStatus.Text = $"Status: {(int)response.StatusCode} {response.StatusCode}";
            lblSize.Text = $"Size: {Encoding.UTF8.GetByteCount(responseContent)}";
            lblTime.Text = $"Time: {stopwatch.ElapsedMilliseconds} ms";

            responseBodyPanel.SetText(responseContent);
        }

        private async Task<HttpResponseMessage> SendRequestAsync(string method, string url, string cookies, int requestsMade = 0)
        {
            if (requestsMade > Globals.MaxRedirects)
            {
                throw new InvalidOperationException("Max redirects reached.");
            }

            using var request = new HttpRequestMessage(MethodMapper(method), url);

            if (cookies.Length > 0)
            {
                request.Headers.Add("Cookie", cookies);
            }

            var response = await httpClient.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.MovedPermanently)
            {
                var movedLocation = response.Headers.Location;

                httpClient.DefaultRequestHeaders.Add("Referer", url);

                return await SendRequestAsync(method, movedLocation.AbsoluteUri, cookies, requestsMade + 1);
            }

            return response;
        }

        private static HttpMethod MethodMapper(string method)
        {
            return method switch
            {
                "GET" => HttpMethod.Get,
                "POST" => HttpMethod.Post,
                "DELETE" => HttpMethod.Delete,
                "PATCH" => HttpMethod.Patch,
                "PUT" => HttpMethod.Put,
                _ => throw new InvalidOperationException($"Unrecognized HttpMethod: {method}"),
            };
        }
    }
}
