using Requestr.Lib.Models;
using Requestr.PostmanImporter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Requestr.Forms
{
    public partial class RequestPanel : UserControl
    {
        private readonly HttpClient httpClient;

        internal RequestPanel(HttpClient httpClient, Request request)
        {
            InitializeComponent();

            this.httpClient = httpClient;

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
            httpClient.DefaultRequestHeaders.Add("User-Agent", $"{Globals.ApplicationName}/{Globals.ApplicationVersion}");
            httpClient.DefaultRequestHeaders.Add("Accept", "*/*");
            httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");

            var request = new HttpRequestMessage(MethodMapper(method), url);

            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var response = await httpClient.SendAsync(request);

            stopwatch.Stop();

            var responseBodyPanel = tabBody.Controls.OfType<ResponseBodyPanel>().Single(c => c.Name == "responseBodyPanel");

            var responseContent = await response.Content.ReadAsStringAsync();

            lblStatus.Text = $"Status: {(int)response.StatusCode} {response.StatusCode}";
            lblSize.Text = $"Size: {Encoding.UTF8.GetByteCount(responseContent)}";
            lblTime.Text = $"Time: {stopwatch.ElapsedMilliseconds} ms";

            responseBodyPanel.SetText(responseContent);
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
