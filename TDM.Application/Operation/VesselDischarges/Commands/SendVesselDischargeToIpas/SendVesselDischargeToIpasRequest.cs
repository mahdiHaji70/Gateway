using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Operation.VesselDischarges.Commands.SendVesselDischargeToIpas
{
    public class SendVesselDischargeToIpasRequest
    {
        public Guid Id { get; set; }
        public string TerminalCode { get; set; } = null!;
        public string ManifestNoticeNo { get; set; } = null!;
        public DateTime DischargeDate { get; set; }
        public Guid IpasItemId { get; set; }
        public Guid CargoTypeId { get; set; }
        public long PackNB { get; set; }
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }
        public string HSCode { get; set; } = null!;
        public string CommodityName { get; set; } = null!;
        public string PackageCode { get; set; } = null!;
        public string? ContainerNo { get; set; }
        public string? ContainerTypeAndCode { get; set; }
        public string? SealNumber { get; set; }
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
