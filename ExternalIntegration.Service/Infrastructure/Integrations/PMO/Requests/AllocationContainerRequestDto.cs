namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class AllocationContainerRequestDto
    {
        public DateTime OperationDate { get; set; }
        public string StorageAreaCode { get; set; }
        public string ContainerNo { get; set; }
        public int Quantity { get; set; }
    }
}