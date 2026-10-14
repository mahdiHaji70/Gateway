using MediatR;

namespace TDM.Application.BasicInformation.OperationTypes.Commands.CreateOperationType
{
    public record CreateOperationTypeCommand : IRequest<Guid>
    {
        public string Name { get; init; } = default!;
        public string Code { get; init; } = default!;
    }
}
