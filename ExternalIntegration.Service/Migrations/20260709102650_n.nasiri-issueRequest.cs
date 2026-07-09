using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExternalIntegration.Service.Migrations
{
    /// <inheritdoc />
    public partial class nnasiriissueRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DischargePermits",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StorageAgreementId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorageAgreementNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorageAgreementTypeId = table.Column<int>(type: "int", nullable: false),
                    StorageAgreementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TerminalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Terminal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TerminalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PortId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Port = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PortCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Issuer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoOwnerPartyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoOwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoOwnerIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoOwnerType = table.Column<int>(type: "int", nullable: false),
                    CargoOwnerRepPartyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoOwnerRepName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoOwnerRepIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoOwnerRepType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DischargePermits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IssueRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Port = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PortCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Terminal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TerminalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerRep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestRemark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskRegisterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GeneralCargoList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BulkList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContainerList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorageAgreementNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueRequests", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DischargePermits");

            migrationBuilder.DropTable(
                name: "IssueRequests");
        }
    }
}
