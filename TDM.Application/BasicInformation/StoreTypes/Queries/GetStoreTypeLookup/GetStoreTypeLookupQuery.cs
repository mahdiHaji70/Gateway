using MediatR;
using TDM.Application.BasicInformation.StoreTypes.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.StoreTypes.Queries.GetStoreTypeLookup
{
    public record GetStoreTypeLookupQuery(string? Search = null, int PageNumber = 1, int PageSize = 20)
        : IRequest<PagedResult<StoreTypeDto>>;
}
