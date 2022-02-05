using System.Net;

namespace Requestr
{
    public static class Globals
    {
        public static string ApplicationName => "Requestr";

        public static string ApplicationVersion => "0.1";

        public static string ApplicationFolder
        {
            get
            {
                var folder = Environment.SpecialFolder.LocalApplicationData;
                var path = Environment.GetFolderPath(folder);

                var appDirectory = Path.Join(path, ApplicationName);

                return appDirectory;
            }
        }

        private static HttpClient httpClient;

        public static HttpClient HttpClient
        {
            get
            {
                if (httpClient == null)
                {
                    var handler = new HttpClientHandler()
                    {
                        AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                    };

                    httpClient = new HttpClient(handler);
                }

                return httpClient;
            }
        }
    }
}