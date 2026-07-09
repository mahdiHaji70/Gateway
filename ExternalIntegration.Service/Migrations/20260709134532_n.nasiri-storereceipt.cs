using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExternalIntegration.Service.Migrations
{
    /// <inheritdoc />
    public partial class nnasiristorereceipt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StoreReceipts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PortId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Port = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TerminalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Terminal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InquiryState = table.Column<int>(type: "int", nullable: false),
                    InquiryStateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InquiryLastTryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerCellPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OwnerType = table.Column<int>(type: "int", nullable: false),
                    OwnerRepName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerRepIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerRepCellPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerRepEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerRepPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerRepAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerRepBirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerRepPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OwnerRepType = table.Column<int>(type: "int", nullable: false),
                    GoodClassificationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemCount = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity_Reserved = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomsProcedureCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DangerousNotNoticed = table.Column<bool>(type: "bit", nullable: true),
                    FirstDischargeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomsProcedureId = table.Column<int>(type: "int", nullable: false),
                    CustomsProcedure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsIssued = table.Column<bool>(type: "bit", nullable: false),
                    GeneralCargoList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BulkList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContainerList = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreReceipts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreReceipts");
        }
    }
}
