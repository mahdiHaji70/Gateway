using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Application.Operation.TerminalDischarges.DTOs
{
    public class TerminalDischargeDto
    {
        public Guid Id { get; set; }
        public Guid DeclarationId { get; set; }
        public string IpasDeclarationNo { get; set; }
        public string TerminalCode { get; set; }
        public Guid CargoTypeId { get; set; }
        public String CargoTypeName { get; set; }
        public Guid StoreId { get; set; }
        public String StoreName { get; set; }
        public Guid DeclarationItemId { get; set; }
        public string WayBillNo { get; set; }
        public Guid WayBillId { get; set; }
        public DateTime DischargeDate { get; set; }
        public string VehicleNumber { get; set; }
        public long PackNB { get; set; }
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }
        public bool IsNonPalletized { get; set; }
        public bool IsDamaged { get; set; }
        public bool IsVoluminous { get; set; }
        public bool IsDangerous { get; set; }
        public string DangerousCode { get; set; }
        public string Classification { get; set; }
        public decimal  IgnitionTemperature { get; set; }
        public string IgnitionTemperatureUnit { get; set; }
        public Guid? IpasTerminalDischargeId { get; set; }
        public DateTime? IpasTerminalDischargeReceivedAt { get; set; }
        public bool? IsSend { get; set; }
    }
}
