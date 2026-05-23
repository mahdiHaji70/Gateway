using MediatR;

namespace TDM.Application.BasicInformation.Commodities.Commands.UpdateCommodity
{
    public record UpdateCommodityCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; init; } = default!;
        public string HSCode { get; init; } = default!;
    }
}
