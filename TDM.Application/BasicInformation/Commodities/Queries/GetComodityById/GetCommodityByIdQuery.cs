using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Commodities.DTOs;
using TDM.Application.BasicInformation.Companies.DTOs;

namespace TDM.Application.BasicInformation.Commodities.Queries.GetComodityById
{
    public record GetCommodityByIdQuery(Guid Id) : IRequest<CommodityDto>;

}
