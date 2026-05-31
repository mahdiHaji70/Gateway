using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addDeclarationItemsDeclarationId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeclarationId",
                schema: "doc",
                table: "DeclarationItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationItems_DeclarationId",
                schema: "doc",
                table: "DeclarationItems",
                column: "DeclarationId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationItems_Declarations_DeclarationId",
                schema: "doc",
                table: "DeclarationItems",
                column: "DeclarationId",
                principalSchema: "doc",
                principalTable: "Declarations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationItems_Declarations_DeclarationId",
                schema: "doc",
                table: "DeclarationItems");

            migrationBuilder.DropIndex(
                name: "IX_DeclarationItems_DeclarationId",
                schema: "doc",
                table: "DeclarationItems");

            migrationBuilder.DropColumn(
                name: "DeclarationId",
                schema: "doc",
                table: "DeclarationItems");
        }
    }
}
