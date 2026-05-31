using MediatR;

namespace TDM.Application.BasicInformation.DeclarationItems.Commands.CreateDeclarationItem
{
    public record CreateDeclarationItemCommand : IRequest<Guid>
    {
        public long Quantity{ get; init; } = default!;
        public decimal GrossWeight { get; init; } = default!;
        public decimal NetWeight { get; init; } = default!;
        public Guid DeclarationId { get; set; }
        public Guid CommodityId { get; set; }
        public Guid PackageId { get; set; }
    }
}
