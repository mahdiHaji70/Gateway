using System;
using System.Collections.Generic;
using System.Text;


namespace TDM.Infrastructure.Integrations.Requests
{
    public class SendTerminalDischargeToIpasDto
    {
        public Guid TerminalDischargeId { get; set; }
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
        public List<SendGeneralCargoTerminalDischargeToIpasDto> GeneralCargoList { get; set; }
        public List<SendBulkTerminalDischargeToIpasDto> BulkList { get; set; }
        public List<SendContainerTerminalDischargeToIpasDto> ContainerList { get; set; }
    }
}
