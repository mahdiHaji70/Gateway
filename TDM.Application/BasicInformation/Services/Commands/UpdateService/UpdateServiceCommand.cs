using MediatR;

namespace TDM.Application.BasicInformation.Services.Commands.UpdateService
{
    public record UpdateServiceCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; init; } = default!;
        public string Code { get; init; } = default!;
    }
}
