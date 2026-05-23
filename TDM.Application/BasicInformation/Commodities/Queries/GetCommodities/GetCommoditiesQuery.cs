using MediatR;
using TDM.Application.BasicInformation.Commodities.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Commodities.Queries.GetCommodities
{
    public record GetCommoditiesQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<CommodityDto>>;

}
