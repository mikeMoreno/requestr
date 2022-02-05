using Requestr.DAL;
using Requestr.Lib;
using Requestr.PostmanImporter;

namespace Requestr
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            SetupApplicationFolder();

            var postmanImporter = new RequestImporter();

            var dbContext = new RequestrDbContext();

            var importService = new ImportService(dbContext, postmanImporter);

            var collectionService = new CollectionService(dbContext);

            var requestService = new RequestService(dbContext);

            Application.Run(new Main(importService, collectionService, requestService));
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