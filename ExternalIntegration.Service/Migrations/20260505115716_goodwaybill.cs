using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExternalIntegration.Service.Migrations
{
    /// <inheritdoc />
    public partial class goodwaybill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GoodwayBills",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SerialNo = table.Column<int>(type: "int", nullable: false),
                    StorageAgreementId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StorageAgreementNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageAgreementDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TerminalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TerminalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Terminal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Port = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransportationCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransportationCompanyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsignerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsignerNationalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsigneeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsigneeNationalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityOriginId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityDestination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityDestinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VehiclePlateNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleDriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleDriverCardNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleDriverPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoodTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoodType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoodPackageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoodPackageTypeId = table.Column<int>(type: "int", nullable: true),
                    GoodPackageQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GoodHSCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoodGrossWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GoodNetWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GoodVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaskId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskOwnerRoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskStage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskStageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskOwnerRoleNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskIsRead = table.Column<bool>(type: "bit", nullable: true),
                    TaskRegisterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaskRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Workflow = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoOwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoOwnerIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoOwnerType = table.Column<int>(type: "int", nullable: true),
                    CargoOwnerRepName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoOwnerRepIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoOwnerRepType = table.Column<int>(type: "int", nullable: false),
                    InquiryState = table.Column<int>(type: "int", nullable: false),
                    PortCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlTraceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityOriginCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityDestinationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehiclePlateNoModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VehiclePlateNoSegmentedValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoodPackageTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginStation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinationStation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WagonNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WagonOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RealWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AcceptedWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerRep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WagonTypeId = table.Column<int>(type: "int", nullable: true),
                    WagonType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoOwnerCellPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoOwnerBirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CargoOwnerTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoOwnerRepCellPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoOwnerRepBirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsReturn = table.Column<bool>(type: "bit", nullable: false),
                    HasDischarge = table.Column<bool>(type: "bit", nullable: false),
                    DischargeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DischargeStateId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BulkList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContainerList = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodwayBills", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodwayBills");
        }
    }
}
