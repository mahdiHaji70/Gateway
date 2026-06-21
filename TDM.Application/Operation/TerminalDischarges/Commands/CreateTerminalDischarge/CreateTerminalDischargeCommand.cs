using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Operation.TerminalDischarges.Commands.CreateTerminalDischarge
{
    public class CreateTerminalDischargeCommand : IRequest<Guid>
    {
        public string TerminalCode { get; set; }
        public Guid CargoTypeId { get; set; }
        public Guid StoreId { get; set; }
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
        public decimal IgnitionTemperature { get; set; }
        public string IgnitionTemperatureUnit { get; set; }
    }
}
