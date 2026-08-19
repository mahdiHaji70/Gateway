namespace TDM.Application.BasicInformation.DeclarationItems.Commands.RequestIpasDeclarationItems
{
    public class IpasDeclarationItemResponse
    {
        public long Quantity{ get; init; } = default!;
        public decimal GrossWeight { get; init; } = default!;
        public decimal NetWeight { get; init; } = default!;
        public string HSCode { get; set; } = default!;
        public string PackageCode { get; set; } = default!;
        public Guid CargoTypeId { get; set; } = default!;

        public List<IpasDeclarationContainerResponse>? Containers { get; set; }

    }

    public class IpasDeclarationContainerResponse
    {
        public string ContainerNo { get; set; } = default!;
        public string ContainerTypeAndSize { get; set; } = default!;
        public string ContainerTypeAndSizeCode { get; set; } = default!;

        public List<IpasDeclarationContainerGoodsResponse>? Goods { get; set; }
    }

    public class IpasDeclarationContainerGoodsResponse
    {
        public string HSCode { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Weight { get; set; }
        public string PackageCode { get; set; } = default!;
        public long Quantity { get; set; }
    }
}