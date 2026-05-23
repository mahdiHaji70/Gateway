using MediatR;

namespace TDM.Application.BasicInformation.Commodities.Commands.CreateCommodity
{
    public record CreateCommodityCommand : IRequest<Guid>
    {
        public string Name { get; init; } = default!;
        public string HSCode { get; init; } = default!;
    }
}
