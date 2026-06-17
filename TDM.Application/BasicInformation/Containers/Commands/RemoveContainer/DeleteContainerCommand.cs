using MediatR;

namespace TDM.Application.BasicInformation.Containers.Commands.RemoveContainer
{
    public class DeleteContainerCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteContainerCommand(Guid id)
        {
            Id = id;
        }
    }
}
