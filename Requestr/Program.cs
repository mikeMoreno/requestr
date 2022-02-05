using Requestr.DAL;
using Requestr.Forms;
using Requestr.Lib;
using Requestr.PostmanImporter;

namespace Requestr
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            SetupApplicationFolder();

            var postmanImporter = new RequestImporter();

            var dbContext = new RequestrDbContext();

            var importService = new ImportService(dbContext, postmanImporter);

            var collectionService = new CollectionService(dbContext);

            var requestService = new RequestService(dbContext);

            var cookieService = new CookieService(dbContext);

            var requestPanelFactory = new RequestPanelFactory(cookieService);

            Application.Run(new Main(importService, collectionService, requestService, requestPanelFactory));
        }


        private static void SetupApplicationFolder()
        {
            if (!Directory.Exists(Globals.ApplicationFolder))
            {
                Directory.CreateDirectory(Globals.ApplicationFolder);
            }
        }
    }
}