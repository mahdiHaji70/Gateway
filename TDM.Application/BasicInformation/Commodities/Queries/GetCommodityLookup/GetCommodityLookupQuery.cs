using MediatR;
using TDM.Application.BasicInformation.Commodities.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Commodities.Queries.GetCommodityLookup
{
    public record GetCommodityLookupQuery(string? Search = null, int PageNumber = 1, int PageSize = 20)
        : IRequest<PagedResult<CommodityDto>>;
}
