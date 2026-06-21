using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Operation.TerminalDischarges.Commands.SendIpasTerminalDischarge
{
    public class SendIpasTerminalDischargeRequest
    {
        public string TerminalCode { get; set; }
        public string AgreementNo { get; set; }
        public string WaybillNo { get; set; }
        public Guid WaybillId { get; set; }
        public DateTime DischargeDate { get; set; }
        public string TruckPlateNumber { get; set; }
        public float TruckEmptyWeight { get; set; }
        public float TruckFullWeight { get; set; }
        public string Tallyman { get; set; }
        public DateTime GateInDateTime { get; set; }
        public DateTime GateOutDateTime { get; set; }
        public List<SendIpasTerminalDischargeGeneralCargoRequest> GeneralCargoList { get; set; }
        public List<SendIpasTerminalDischargeBulkRequest> BulkList { get; set; }
        public List<SendIpasTerminalDischargeContainerRequest> ContainerList { get; set; }
    }
}
