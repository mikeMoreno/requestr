using Microsoft.EntityFrameworkCore;
using Requestr.DAL.Models;

namespace Requestr.DAL
{
    public class RequestrDbContext : DbContext
    {
        const string DbName = "requestr.db";

        public DbSet<RequestCollection> RequestCollections { get; set; }

        public DbSet<Request> Requests { get; set; }

        public DbSet<CookieInfo> CookieInfos { get; set; }

        public string FullDatabasePath { get; }

        public RequestrDbContext()
        {
            SetupApplicationFolder();

            FullDatabasePath = Path.Join(Globals.ApplicationFolder, DbName);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={FullDatabasePath}");


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Request>().HasOne(typeof(RequestCollection), "RequestCollection")
                .WithMany("Requests")
                .HasForeignKey("RequestCollectionId");

            builder.Entity<RequestHeader>().HasOne(typeof(Request), "Request")
                .WithMany("RequestHeaders")
                .HasForeignKey("RequestId");
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