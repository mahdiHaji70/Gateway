using MediatR;
using TDM.Application.BasicInformation.ContainerTypesAndSizes.DTOs;
using TDM.Application.BasicInformation.Packages.DTOs;

namespace TDM.Application.BasicInformation.ContainerTypesAndSizes.Queries.GetContainerTypeAndSizeById
{
    public record GetContainerTypeAndSizeByIdQuery(Guid Id) : IRequest<ContainerTypeAndSizeDto>;

}
