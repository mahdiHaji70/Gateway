using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class change_container_to_id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "No",
                schema: "doc",
                table: "DeclarationContainers");

            migrationBuilder.DropColumn(
                name: "TypeAndSize",
                schema: "doc",
                table: "DeclarationContainers");

            migrationBuilder.DropColumn(
                name: "TypeAndSizeCode",
                schema: "doc",
                table: "DeclarationContainers");

            migrationBuilder.AddColumn<Guid>(
                name: "ContainerId",
                schema: "doc",
                table: "DeclarationContainers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ContainerId",
                schema: "basicInfo",
                table: "Containers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationContainers_ContainerId",
                schema: "doc",
                table: "DeclarationContainers",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_ContainerId",
                schema: "basicInfo",
                table: "Containers",
                column: "ContainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_Containers_ContainerId",
                schema: "basicInfo",
                table: "Containers",
                column: "ContainerId",
                principalSchema: "basicInfo",
                principalTable: "Containers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationContainers_Containers_ContainerId",
                schema: "doc",
                table: "DeclarationContainers",
                column: "ContainerId",
                principalSchema: "basicInfo",
                principalTable: "Containers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Containers_Containers_ContainerId",
                schema: "basicInfo",
                table: "Containers");

            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationContainers_Containers_ContainerId",
                schema: "doc",
                table: "DeclarationContainers");

            migrationBuilder.DropIndex(
                name: "IX_DeclarationContainers_ContainerId",
                schema: "doc",
                table: "DeclarationContainers");

            migrationBuilder.DropIndex(
                name: "IX_Containers_ContainerId",
                schema: "basicInfo",
                table: "Containers");

            migrationBuilder.DropColumn(
                name: "ContainerId",
                schema: "doc",
                table: "DeclarationContainers");

            migrationBuilder.DropColumn(
                name: "ContainerId",
                schema: "basicInfo",
                table: "Containers");

            migrationBuilder.AddColumn<string>(
                name: "No",
                schema: "doc",
                table: "DeclarationContainers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TypeAndSize",
                schema: "doc",
                table: "DeclarationContainers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TypeAndSizeCode",
                schema: "doc",
                table: "DeclarationContainers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
