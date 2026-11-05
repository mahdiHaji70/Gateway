using MediatR;
using TDM.Application.BasicInformation.Stores.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Stores.Queries.GetStoreLookup
{
    public record GetStoreLookupQuery(string? Search = null, int PageNumber = 1, int PageSize = 20)
        : IRequest<PagedResult<StoreDto>>;
}
