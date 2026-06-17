using MediatR;

namespace TDM.Application.BasicInformation.Containers.Commands.UpdateContainer
{
    public record UpdateContainerCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string No { get; init; } = default!;        
        public Guid ContainerTypeAndSizeId { get; set; }
    }
}
