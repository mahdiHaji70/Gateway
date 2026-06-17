using MediatR;
using TDM.Application.BasicInformation.ContainerTypesAndSizes.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.ContainerTypesAndSizes.Queries.GetContainerTypesAndSizes
{
    public record GetContainerTypesAndSizesQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<ContainerTypeAndSizeDto>>;

}
