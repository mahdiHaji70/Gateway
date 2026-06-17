
namespace TDM.Application.Doc.DeclarationItems.DTOs
{
    public class DeclarationContainerGoodDto
    {
        public long Quantity { get; set; }
        public decimal Weight { get; set; }
        public Guid CommodityId { get; set; }
        public string? CommodityName { get; set; }
        public Guid PackageId { get; set; }
        public string? PackageName { get; set; }
        public Guid DeclarationContainerId { get; set; }

    }
}
