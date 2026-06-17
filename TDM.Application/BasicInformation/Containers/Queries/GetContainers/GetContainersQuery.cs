using MediatR;
using TDM.Application.BasicInformation.Cities.DTOs;
using TDM.Application.BasicInformation.Containers.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Containers.Queries.GetContainers
{
    public record GetContainersQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<ContainerDto>>;

}
