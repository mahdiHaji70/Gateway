using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addTrafficIdAndDescriptionToDeclaration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "doc",
                table: "Declarations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IpasDeclarationId",
                schema: "doc",
                table: "Declarations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IpasDeclarationIdReceivedAt",
                schema: "doc",
                table: "Declarations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TrafficId",
                schema: "doc",
                table: "Declarations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Declarations_TrafficId",
                schema: "doc",
                table: "Declarations",
                column: "TrafficId");

            migrationBuilder.AddForeignKey(
                name: "FK_Declarations_Traffics_TrafficId",
                schema: "doc",
                table: "Declarations",
                column: "TrafficId",
                principalSchema: "basicInfo",
                principalTable: "Traffics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Declarations_Traffics_TrafficId",
                schema: "doc",
                table: "Declarations");

            migrationBuilder.DropIndex(
                name: "IX_Declarations_TrafficId",
                schema: "doc",
                table: "Declarations");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "doc",
                table: "Declarations");

            migrationBuilder.DropColumn(
                name: "IpasDeclarationId",
                schema: "doc",
                table: "Declarations");

            migrationBuilder.DropColumn(
                name: "IpasDeclarationIdReceivedAt",
                schema: "doc",
                table: "Declarations");

            migrationBuilder.DropColumn(
                name: "TrafficId",
                schema: "doc",
                table: "Declarations");
        }
    }
}
