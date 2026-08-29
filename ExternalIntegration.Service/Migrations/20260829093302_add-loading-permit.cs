using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExternalIntegration.Service.Migrations
{
    /// <inheritdoc />
    public partial class addloadingpermit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoadingPermits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PortId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Port = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TerminalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Terminal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TerminalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SerialNo = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Party = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartyIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoodClassification = table.Column<int>(type: "int", nullable: false),
                    GoodClassificationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoUnitiziseTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerType = table.Column<int>(type: "int", nullable: false),
                    OwnerRepName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerRepIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerRepType = table.Column<int>(type: "int", nullable: false),
                    WarehouseReceiptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseReceiptNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskOwnerRoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskStage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskStageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskOwnerRoleNames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskIsRead = table.Column<bool>(type: "bit", nullable: false),
                    TaskRemark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Workflow = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskRegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BulkList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneralCargoList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContainerList = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadingPermits", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoadingPermits");
        }
    }
}
