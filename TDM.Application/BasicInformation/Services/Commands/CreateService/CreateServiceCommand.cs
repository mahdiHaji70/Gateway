using MediatR;

namespace TDM.Application.BasicInformation.Services.Commands.CreateService
{
    public record CreateServiceCommand : IRequest<Guid>
    {
        public string Name { get; init; } = default!;
        public string Code { get; init; } = default!;
    }
}
