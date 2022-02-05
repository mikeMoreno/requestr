using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Requestr.DAL.Migrations
{
    public partial class SchemaChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Requests",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Method",
                table: "Requests",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CollectionId",
                table: "Requests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RequestCollections",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CollectionId",
                table: "Requests",
                column: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_RequestCollections_CollectionId",
                table: "Requests",
                column: "CollectionId",
                principalTable: "RequestCollections",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_RequestCollections_CollectionId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_CollectionId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "RequestCollections");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Requests",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Method",
                table: "Requests",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
