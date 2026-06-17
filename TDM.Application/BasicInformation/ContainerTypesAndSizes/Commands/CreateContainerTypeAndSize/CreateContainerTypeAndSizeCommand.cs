using MediatR;

namespace TDM.Application.BasicInformation.ContainerTypesAndSizes.Commands.CreateContainerTypeAndSize
{
    public record CreateContainerTypeAndSizeCommand : IRequest<Guid>
    {
        public string TypeAndSize { get; init; } = default!;
        public string TypeAndSizeCode { get; init; } = default!;
    }
}
