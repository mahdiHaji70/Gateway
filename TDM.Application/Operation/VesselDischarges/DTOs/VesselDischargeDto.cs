using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Application.Operation.VesselDischarges.DTOs
{
    public class VesselDischargeDto
    {
        public Guid Id { get; set; }
        public string TerminalCode { get; private set; } = null!;

        public Guid StoreId { get; private set; }
        public string StoreName { get; private set; } = null!;

        public Guid ManifestItemId { get; private set; }
        public string ManifestItemNo { get; private set; } = null!;
        public string ManifestNo { get; private set; } = null!;

        public Guid? ManifestContainerId { get; set; }
        public string? ContainerNo { get; set; }

        public DateTime DischargeDate { get; private set; }
        public long PackNB { get; private set; }
        public decimal Weight { get; private set; }
        public decimal Volume { get; private set; }

        public bool IsNonPalletized { get; private set; }
        public bool IsDamaged { get; private set; }
        public bool IsVoluminous { get; private set; }
        public bool IsDangerous { get; private set; }

        public string? DangerousCode { get; private set; }
        public string? Classification { get; private set; }

        public decimal? IgnitionTemperature { get; private set; }
        public string? IgnitionTemperatureUnit { get; private set; }

        public Guid? IpasVesselDischargeId { get; private set; }
        public DateTime? IpasVesselDischargeReceivedAt { get; private set; }

        public decimal UnitWeight { get; private set; }

        public bool IsSend { get; set; }
    }
}
