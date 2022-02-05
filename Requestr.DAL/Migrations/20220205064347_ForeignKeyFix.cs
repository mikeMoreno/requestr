using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Requestr.DAL.Migrations
{
    public partial class ForeignKeyFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "RequestCollectionId",
                table: "Requests",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestCollectionId",
                table: "Requests",
                column: "RequestCollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_RequestCollections_RequestCollectionId",
                table: "Requests",
                column: "RequestCollectionId",
                principalTable: "RequestCollections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_RequestCollections_RequestCollectionId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RequestCollectionId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestCollectionId",
                table: "Requests");

            migrationBuilder.AddColumn<Guid>(
                name: "CollectionId",
                table: "Requests",
                type: "TEXT",
                nullable: true);

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
    }
}
