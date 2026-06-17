namespace TDM.Application.Doc.DeclarationItems.DTOs
{
    public class DeclarationContainerDto
    {
        public Guid ContainerId { get; set; }
        public string? ContainerNo { get; set; }
        public string? ContainerTypeAndSize { get; set; }
        public Guid DeclarationItemId { get; set; }
        public List<DeclarationContainerGoodDto>? DeclarationContainerGoods { get; set; }

    }
}
