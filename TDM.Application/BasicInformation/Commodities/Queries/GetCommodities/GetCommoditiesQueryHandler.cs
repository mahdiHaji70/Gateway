using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Commodities.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Commodities.Queries.GetCommodities
{
    public class GetCommoditiesQueryHandler : IRequestHandler<GetCommoditiesQuery, PagedResult<CommodityDto>>
    {
        private readonly ICommodityRepository _commodityRepository;
        private readonly IMapper _mapper;

        public GetCommoditiesQueryHandler(IMapper mapper,
            ICommodityRepository commodityRepository)
        {
            _commodityRepository = commodityRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CommodityDto>> Handle(
        GetCommoditiesQuery request,
        CancellationToken cancellationToken)
        {
            var commodities = await _commodityRepository.GetPagedAsync(request.PageNumber, request.PageSize, request.Search);

            return _mapper.Map<PagedResult<CommodityDto>>(commodities);
        }
    }
}
