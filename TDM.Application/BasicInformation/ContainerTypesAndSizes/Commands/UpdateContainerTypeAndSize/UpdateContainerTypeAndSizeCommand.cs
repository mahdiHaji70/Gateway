using MediatR;

namespace TDM.Application.BasicInformation.ContainerTypesAndSizes.Commands.UpdateContainerTypeAndSize
{
    public record UpdateContainerTypeAndSizeCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string TypeAndSize { get; init; } = default!;
        public string TypeAndSizeCode { get; init; } = default!;
    }
}
