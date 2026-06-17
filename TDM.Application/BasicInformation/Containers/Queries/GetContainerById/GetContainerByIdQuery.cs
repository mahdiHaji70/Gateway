using MediatR;
using TDM.Application.BasicInformation.Cities.DTOs;
using TDM.Application.BasicInformation.Containers.DTOs;

namespace TDM.Application.BasicInformation.Containers.Queries.GetContainerById
{
    public record GetContainerByIdQuery(Guid Id) : IRequest<ContainerDto>;

}
