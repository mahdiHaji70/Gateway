using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Operation.TerminalDischarges.Commands.SendIpasTerminalDischarge
{
    public class SendIpasTerminalDischargeRequest
    {
        public string TerminalCode { get; set; }
        public string IpasDeclarationNo { get; set; }
        public string WaybillNo { get; set; }
        public Guid WaybillId { get; set; }
        public DateTime DischargeDate { get; set; }
        public string VehicleNumber { get; set; }
        public Guid CargoTypeId { get; set; }
        public string CargoTypeName { get; set; }
        public string HSCode { get; set; }
        public Guid CommodityId { get; set; }
        public string CommodityName { get; set; }
        public Guid PackageId { get; set; }
        public string PackageCode { get; set; }
        public string PackageName { get; set; }
        public long PackNB { get; set; }
        public decimal Weight {  get; set; }
        public decimal Volume { get; set; }
        public bool IsNonPalletized { get; set; }
        public bool IsDamaged { get; set; }
        public bool IsVoluminous { get; set; }
        public bool IsDangerous { get; set; }
        public string DangerousCode { get; set; }
        public string Classification { get; set; }
        public decimal IgnitionTemperature { get; set; }
        public string IgnitionTemperatureUnit { get; set; }
        public string ContainerNo { get; set; }

    }
}
