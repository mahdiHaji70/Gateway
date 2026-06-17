using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class nfeatInfoBaseTerminalDischargeCahngeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TerminalDischarges_CargoTypes_CargoTypeId1",
                schema: "operation",
                table: "TerminalDischarges");

            migrationBuilder.DropForeignKey(
                name: "FK_TerminalDischarges_DeclarationItems_DeclarationItemId",
                schema: "operation",
                table: "TerminalDischarges");

            migrationBuilder.DropForeignKey(
                name: "FK_TerminalDischarges_Stores_StoreId1",
                schema: "operation",
                table: "TerminalDischarges");

            migrationBuilder.DropIndex(
                name: "IX_TerminalDischarges_CargoTypeId1",
                schema: "operation",
                table: "TerminalDischarges");

            migrationBuilder.DropIndex(
                name: "IX_TerminalDischarges_StoreId1",
                schema: "operation",
                table: "TerminalDischarges");

            migrationBuilder.DropColumn(
                name: "CargoTypeId1",
                schema: "operation",
                table: "TerminalDischarges");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                schema: "operation",
                table: "TerminalDischarges");

            //migrationBuilder.DropColumn(
            //    name: "StoreId1",
            //    schema: "operation",
            //    table: "TerminalDischarges");

            //migrationBuilder.AlterColumn<Guid>(
            //    name: "StoreId",
            //    schema: "operation",
            //    table: "TerminalDischarges",
            //    type: "uniqueidentifier",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            //migrationBuilder.AlterColumn<Guid>(
            //    name: "CargoTypeId",
            //    schema: "operation",
            //    table: "TerminalDischarges",
            //    type: "uniqueidentifier",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_TerminalDischarges_StoreId",
                schema: "operation",
                table: "TerminalDischarges",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_TerminalDischarges_CargoTypes_StoreId",
                schema: "operation",
                table: "TerminalDischarges",
                column: "StoreId",
                principalSchema: "basicInfo",
                principalTable: "CargoTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TerminalDischarges_DeclarationItems_DeclarationItemId",
                schema: "operation",
                table: "TerminalDischarges",
                column: "DeclarationItemId",
                principalSchema: "doc",
                principalTable: "DeclarationItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TerminalDischarges_Stores_StoreId",
                schema: "operation",
                table: "TerminalDischarges",
                column: "StoreId",
                principalSchema: "basicInfo",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TerminalDischarges_CargoTypes_StoreId",
                schema: "operation",
                table: "TerminalDischarges");

            migrationBuilder.DropForeignKey(
                name: "FK_TerminalDischarges_DeclarationItems_DeclarationItemId",
                schema: "operation",
                table: "TerminalDischarges");

            migrationBuilder.DropForeignKey(
                name: "FK_TerminalDischarges_Stores_StoreId",
                schema: "operation",
                table: "TerminalDischarges");

            migrationBuilder.DropIndex(
                name: "IX_TerminalDischarges_StoreId",
                schema: "operation",
                table: "TerminalDischarges");

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                schema: "operation",
                table: "TerminalDischarges",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "CargoTypeId",
                schema: "operation",
                table: "TerminalDischarges",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "CargoTypeId1",
                schema: "operation",
                table: "TerminalDischarges",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                schema: "operation",
                table: "TerminalDischarges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId1",
                schema: "operation",
                table: "TerminalDischarges",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TerminalDischarges_CargoTypeId1",
                schema: "operation",
                table: "TerminalDischarges",
                column: "CargoTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_TerminalDischarges_StoreId1",
                schema: "operation",
                table: "TerminalDischarges",
                column: "StoreId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TerminalDischarges_CargoTypes_CargoTypeId1",
                schema: "operation",
                table: "TerminalDischarges",
                column: "CargoTypeId1",
                principalSchema: "basicInfo",
                principalTable: "CargoTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TerminalDischarges_DeclarationItems_DeclarationItemId",
                schema: "operation",
                table: "TerminalDischarges",
                column: "DeclarationItemId",
                principalSchema: "doc",
                principalTable: "DeclarationItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TerminalDischarges_Stores_StoreId1",
                schema: "operation",
                table: "TerminalDischarges",
                column: "StoreId1",
                principalSchema: "basicInfo",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
