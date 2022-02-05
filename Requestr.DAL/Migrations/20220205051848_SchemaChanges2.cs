using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Requestr.DAL.Migrations
{
    public partial class SchemaChanges2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Requests",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Requests");
        }
    }
}
