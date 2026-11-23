using TDM.Application.Doc.StoreReceipts.Commands.SendSeaExitDeliveryToIpas;

namespace TDM.Infrastructure.Integrations.Requests
{
    public class SendSeaExitDeliveryToIpasDto
    {
        public Guid LoadingPermitId { get; set; }
        public string TerminalCode { get; set; } = null!;
        public DateTime Date { get; set; }
        public int VehicleTypeId { get; set; }
        public string VehicleNo { get; set; } = null!;
        public DateTime LoadingStart { get; set; }
        public DateTime LoadingFinish { get; set; }
        public string? Remark { get; set; }
        public List<SeaExitDeliveryGeneralCargo> GeneralCargoList { get; set; } = [];
        public List<SeaExitDeliveryBulk> BulkList { get; set; } = [];
        public List<string> ContainerList { get; set; } = [];
    }
}
