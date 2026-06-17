using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class nfeatInfoBaseTerminalDischarge2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_StoreTypes_StoreTypeId",
                schema: "basicInfo",
                table: "Stores");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_StoreTypes_StoreTypeId",
                schema: "basicInfo",
                table: "Stores",
                column: "StoreTypeId",
                principalSchema: "basicInfo",
                principalTable: "StoreTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_StoreTypes_StoreTypeId",
                schema: "basicInfo",
                table: "Stores");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_StoreTypes_StoreTypeId",
                schema: "basicInfo",
                table: "Stores",
                column: "StoreTypeId",
                principalSchema: "basicInfo",
                principalTable: "StoreTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
