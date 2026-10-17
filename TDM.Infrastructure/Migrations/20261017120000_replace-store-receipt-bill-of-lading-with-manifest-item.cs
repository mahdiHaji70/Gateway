using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDM.Infrastructure.Migrations
{
    public partial class replacestorereceiptbillofladingwithmanifestitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillOfLadingId",
                schema: "doc",
                table: "StoreReceiptHeads");

            migrationBuilder.AddColumn<Guid>(
                name: "ManifestItemId",
                schema: "doc",
                table: "StoreReceiptHeads",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreReceiptHeads_ManifestItemId",
                schema: "doc",
                table: "StoreReceiptHeads",
                column: "ManifestItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreReceiptHeads_ManifestItems_ManifestItemId",
                schema: "doc",
                table: "StoreReceiptHeads",
                column: "ManifestItemId",
                principalSchema: "doc",
                principalTable: "ManifestItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreReceiptHeads_ManifestItems_ManifestItemId",
                schema: "doc",
                table: "StoreReceiptHeads");

            migrationBuilder.DropIndex(
                name: "IX_StoreReceiptHeads_ManifestItemId",
                schema: "doc",
                table: "StoreReceiptHeads");

            migrationBuilder.DropColumn(
                name: "ManifestItemId",
                schema: "doc",
                table: "StoreReceiptHeads");

            migrationBuilder.AddColumn<Guid>(
                name: "BillOfLadingId",
                schema: "doc",
                table: "StoreReceiptHeads",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
