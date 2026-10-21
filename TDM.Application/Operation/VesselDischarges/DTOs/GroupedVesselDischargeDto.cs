using System;

namespace TDM.Application.Operation.VesselDischarges.DTOs
{
    public class GroupedVesselDischargeDto
    {
        public string TerminalCode { get; set; }
        public Guid StoreId { get; set; }
        public string StoreName { get; set; }
        public Guid ManifestItemId { get; set; }
        public string ManifestItemNo { get; set; }
        public string ManifestNo { get; set; }
        public Guid? ManifestContainerId { get; set; }
        public string? ContainerNo { get; set; }
        public DateTime DischargeDate { get; set; }
        public long PackNB { get; set; }
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }
        public bool IsNonPalletized { get; set; }
        public bool IsDamaged { get; set; }
        public bool IsVoluminous { get; set; }
        public bool IsDangerous { get; set; }
        public string? DangerousCode { get; set; }
        public string? Classification { get; set; }
        public decimal? IgnitionTemperature { get; set; }
        public string? IgnitionTemperatureUnit { get; set; }
        public Guid? IpasVesselDischargeId { get; set; }
        public DateTime? IpasVesselDischargeReceivedAt { get; set; }
        public decimal UnitWeight { get; set; }
        public bool IsSend { get; set; }
    }
}
