using TDM.Application.Doc.StoreReceipts.Commands.SendLandExitDeliveryToIpas;

namespace TDM.Infrastructure.Integrations.Requests
{
    public class SendLandExitDeliveryToIpasDto
    {
        public Guid LoadingPermitId { get; set; }
        public string TerminalCode { get; set; } = null!;
        public DateTime Date { get; set; }
        public int VehicleTypeId { get; set; }
        public string VehicleNo { get; set; } = null!;
        public DateTime LoadingStart { get; set; }
        public DateTime LoadingFinish { get; set; }
        public string? Remark { get; set; }
        public string StorageAreaCode { get; set; } = null!;
        public DateTime FirstPortDischargeDate { get; set; }
        public DateTime FirstTerminalDischargeDate { get; set; }
        public List<LandExitDeliveryGeneralCargo> GeneralCargoList { get; set; } = [];
        public List<LandExitDeliveryBulk> BulkList { get; set; } = [];
        public List<string> ContainerList { get; set; } = [];
    }
}
