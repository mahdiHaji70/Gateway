using MediatR;

namespace TDM.Application.BasicInformation.Traffics.Commands.UpdateTraffic
{
    public record UpdateTrafficCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; init; } = default!;
        public string Code { get; init; } = default!;
    }
}
