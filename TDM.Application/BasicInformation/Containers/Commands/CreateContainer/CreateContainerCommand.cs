using MediatR;

namespace TDM.Application.BasicInformation.Containers.Commands.CreateContainer
{
    public record CreateContainerCommand : IRequest<Guid>
    {
        public string No { get; init; } = default!;        
        public Guid ContainerTypeAndSizeId { get; set; }
    }
}
