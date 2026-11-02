using MediatR;
using TDM.Application.BasicInformation.Containers.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Containers.Queries.GetContainerLookup
{
    public record GetContainerLookupQuery(string? Search = null, int PageNumber = 1, int PageSize = 20)
        : IRequest<PagedResult<ContainerDto>>;
}
