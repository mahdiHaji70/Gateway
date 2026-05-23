using MediatR;

namespace TDM.Application.BasicInformation.Traffics.Commands.CreateTraffic
{
    public record CreateTrafficCommand : IRequest<Guid>
    {
        public string Name { get; init; } = default!;
        public string Code { get; init; } = default!;
    }
}
