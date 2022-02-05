using System.Net;

namespace Requestr
{
    public static class Globals
    {
        public static string ApplicationName => "Requestr";

        public static string ApplicationVersion => "0.1";

        public static int MaxRedirects = 10;

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
    }
}