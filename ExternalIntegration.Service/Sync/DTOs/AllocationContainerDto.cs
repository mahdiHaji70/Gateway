namespace ExternalIntegration.Service.Sync.DTOs
{
    public class AllocationContainerDto
    {
        public DateTime OperationDate { get; set; }
        public string StorageAreaCode { get; set; }
        public string ContainerNo { get; set; }
        public int Quantity { get; set; }
    }
}