using MediatR;
using TDM.Application.BasicInformation.ContainerTypesAndSizes.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.ContainerTypesAndSizes.Queries.GetContainerTypeAndSizeLookup
{
    public record GetContainerTypeAndSizeLookupQuery(string? Search = null, int PageNumber = 1, int PageSize = 20)
        : IRequest<PagedResult<ContainerTypeAndSizeDto>>;
}
