using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

            using IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) => services
                            .AddSingleton<RequestrDbContext>()
                            .AddSingleton<RequestPanelFactory>()
                            .AddSingleton<IRequestImporter, RequestImporter>()
                            .AddSingleton<IRequestService, RequestService>()
                            .AddSingleton<IImportService, ImportService>()
                            .AddSingleton<ICollectionService, CollectionService>()
                            .AddSingleton<ICookieService, CookieService>()
                            .AddSingleton<Main>())
                            .Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                Application.Run(services.GetRequiredService<Main>());
            }
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