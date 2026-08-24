using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Operation.VesselDischarges.Commands.UpdateVesselDischarge
{
    public class UpdateVesselDischargeCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string TerminalCode { get; set; } = null!;

        public Guid StoreId { get; set; }
        public Guid ManifestItemId { get; set; }
        public Guid ManifestContainerId { get; set; }

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

        public decimal IgnitionTemperature { get; set; }
        public string? IgnitionTemperatureUnit { get; set; }

        public decimal UnitWeight { get; set; }
    }
}
