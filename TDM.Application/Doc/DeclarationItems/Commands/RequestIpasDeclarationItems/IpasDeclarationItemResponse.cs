namespace TDM.Application.BasicInformation.DeclarationItems.Commands.RequestIpasDeclarationItems
{
    public class IpasDeclarationItemResponse
    {
        public long Quantity{ get; init; } = default!;
        public decimal GrossWeight { get; init; } = default!;
        public decimal NetWeight { get; init; } = default!;
        public string HSCode { get; set; } = default!;
        public string PackageCode { get; set; } = default!;

    }
}