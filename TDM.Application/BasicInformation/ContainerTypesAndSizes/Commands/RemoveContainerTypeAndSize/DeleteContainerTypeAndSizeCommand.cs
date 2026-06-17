using MediatR;

namespace TDM.Application.BasicInformation.ContainerTypesAndSizes.Commands.RemoveContainerTypeAndSize
{
    public class DeleteContainerTypeAndSizeCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteContainerTypeAndSizeCommand(Guid id)
        {
            Id = id;
        }
    }
}
