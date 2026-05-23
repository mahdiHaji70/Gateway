using MediatR;
using TDM.Application.BasicInformation.Commodities.DTOs;

namespace TDM.Application.BasicInformation.Commodities.Queries.GetComodityById
{
    public record GetCommodityByIdQuery(Guid Id) : IRequest<CommodityDto>;

}
