using AngleSharp.Html;
using AngleSharp.Html.Parser;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Requestr.Lib;
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
        private readonly ICookieService cookieService;

        internal RequestPanel(Request request, ICookieService cookieService)
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

            InitializeDefaultHeaders();
        }

        private async void BtnSend_Click(object sender, EventArgs e)
        {
            var method = comboMethod.SelectedItem as string;
            var url = textUrl.Text;
            var body = txtRequestBody.Text;

            if (string.IsNullOrWhiteSpace(url))
            {
                return;
            }

            await SetupHeadersAsync(httpClient, url);

            var stopwatch = new Stopwatch();

            stopwatch.Start();

            using var response = await SendRequestAsync(method, url, body);

            stopwatch.Stop();

            if (response.Headers.TryGetValues("Set-Cookie", out var setCookies))
            {
                await cookieService.SetCookiesAsync(setCookies);
            }

            var responseContent = await response.Content.ReadAsStringAsync();

            lblStatus.Text = $"Status: {(int)response.StatusCode} {response.StatusCode}";
            lblSize.Text = $"Size: {Encoding.UTF8.GetByteCount(responseContent)}";
            lblTime.Text = $"Time: {stopwatch.ElapsedMilliseconds} ms";

            txtResponseBody.Text = FormatResponse(responseContent);
        }

        private void InitializeDefaultHeaders()
        {
            var headers = new StringBuilder();
            headers.AppendLine("Cache-Control no-cache");
            headers.AppendLine($"{Globals.ApplicationName}-Token $GUID");
            headers.AppendLine($"User-Agent {Globals.ApplicationName}/{Globals.ApplicationVersion}");
            headers.AppendLine("Accept */*");
            headers.AppendLine("Accept-Encoding gzip, deflate, br");
            headers.AppendLine("Connection keep-alive");

            txtHeaders.Text = headers.ToString();
        }

        private async Task SetupHeadersAsync(HttpClient httpClient, string url)
        {
            httpClient.DefaultRequestHeaders.Clear();

            foreach (var line in txtHeaders.Text.Split('\n'))
            {
                if (line.Trim().StartsWith("#"))
                {
                    continue;
                }

                if (line.Trim() == "")
                {
                    continue;
                }

                if (!line.Contains(' '))
                {
                    continue;
                }

                var key = line[..line.IndexOf(' ')].Trim();
                var value = line[(line.IndexOf(' ') + 1)..].Trim();

                value = value.Replace("$GUID", Guid.NewGuid().ToString());

                httpClient.DefaultRequestHeaders.Add(key, value);
            }

            var cookies = await cookieService.GetCookiesAsync(url);

            if (cookies.Length > 0)
            {
                httpClient.DefaultRequestHeaders.Add("Cookie", cookies);
            }
        }

        private static string FormatResponse(string responseContent)
        {
            try
            {
                var parser = new HtmlParser();
                var document = parser.ParseDocument(responseContent);

                using var writer = new StringWriter();

                document.ToHtml(writer, new PrettyMarkupFormatter
                {
                    Indentation = "\t",
                    NewLine = "\n"
                });

                var indentedText = writer.ToString();

                return indentedText;
            }
            catch
            {
                return responseContent;
            }
        }

        private async Task<HttpResponseMessage> SendRequestAsync(string method, string url, string body = null, int requestsMade = 0)
        {
            var httpMethod = MethodMapper(method);

            if (requestsMade > Globals.MaxRedirects)
            {
                throw new InvalidOperationException("Max redirects reached.");
            }

            using var request = new HttpRequestMessage(httpMethod, url);

            if (!string.IsNullOrWhiteSpace(body))
            {
                //var json = JsonSerializer.Serialize(body);

                var content = new StringContent(body, Encoding.UTF8, "application/json");

                request.Content = content;
            }

            var response = await httpClient.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.MovedPermanently)
            {
                var movedLocation = response.Headers.Location;

                httpClient.DefaultRequestHeaders.Add("Referer", url);

                return await SendRequestAsync(method, movedLocation.AbsoluteUri, body, requestsMade + 1);
            }

            return response;
        }

        private void BtnFormat_Click(object sender, EventArgs e)
        {
            var requestText = txtRequestBody.Text;

            string jsonFormatted = JToken.Parse(requestText).ToString(Formatting.Indented);

            txtRequestBody.Text = jsonFormatted;
        }

        private void BtnFormatRequestHeaders_Click(object sender, EventArgs e)
        {
            var headers = txtHeaders.Text;

            Console.WriteLine(headers);
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
