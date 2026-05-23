using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Commodities.DTOs;
using TDM.Application.BasicInformation.Companies.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Commodities.Queries.GetCommodities
{
    public class GetCommoditiesQueryHandler : IRequestHandler<GetCommoditiesQuery, PagedResult<CommodityDto>>
    {
        private readonly IRepository<Commodity> _commodityRepository;
        private readonly IMapper _mapper;

        public GetCommoditiesQueryHandler(IMapper mapper,
            IRepository<Commodity> commodityRepository)
        {
            _commodityRepository = commodityRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CommodityDto>> Handle(
        GetCommoditiesQuery request,
        CancellationToken cancellationToken)
        {
            var commodities = await _commodityRepository.GetPagedAsync(request.PageNumber, request.PageSize);

            return _mapper.Map<PagedResult<CommodityDto>>(commodities);
        }
    }
}
