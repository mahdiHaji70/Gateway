using TDM.Application.Doc.StoreReceipts.Commands.SendVesselLoadingToIpas;

namespace TDM.Infrastructure.Integrations.Requests
{
    public class SendVesselLoadingToIpasDto
    {
        // Used to select the terminal's authentication token, not sent as a service parameter.
        public string TerminalCode { get; set; } = null!;
        public DateTime Date { get; set; }
        public Guid VoyageId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public string CarrierIdNumber { get; set; } = null!;
        public int CarrierType { get; set; }
        public string TallyMan { get; set; } = null!;
        public string? Remark { get; set; }
        public List<VesselLoadingGeneralCargo> GeneralCargoList { get; set; } = [];
        public List<VesselLoadingBulk> BulkList { get; set; } = [];
        public List<VesselLoadingContainer> ContainerList { get; set; } = [];
    }
}
