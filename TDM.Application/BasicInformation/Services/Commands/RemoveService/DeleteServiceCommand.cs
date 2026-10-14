using MediatR;

namespace TDM.Application.BasicInformation.Services.Commands.RemoveService
{
    public record DeleteServiceCommand(Guid Id) : IRequest<bool>;
}
