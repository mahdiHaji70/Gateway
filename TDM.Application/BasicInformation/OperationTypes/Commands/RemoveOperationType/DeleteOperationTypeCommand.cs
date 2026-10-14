using MediatR;

namespace TDM.Application.BasicInformation.OperationTypes.Commands.RemoveOperationType
{
    public class DeleteOperationTypeCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteOperationTypeCommand(Guid id)
        {
            Id = id;
        }
    }
}
