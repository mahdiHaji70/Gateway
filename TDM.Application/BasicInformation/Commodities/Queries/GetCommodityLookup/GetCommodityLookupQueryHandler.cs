using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Commodities.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Commodities.Queries.GetCommodityLookup
{
    public class GetCommodityLookupQueryHandler : IRequestHandler<GetCommodityLookupQuery, PagedResult<CommodityDto>>
    {
        private readonly ICommodityRepository _repository;
        private readonly IMapper _mapper;

        public GetCommodityLookupQueryHandler(ICommodityRepository repository, IMapper mapper)
        { _repository = repository; _mapper = mapper; }

        public async Task<PagedResult<CommodityDto>> Handle(GetCommodityLookupQuery request, CancellationToken cancellationToken)
            => _mapper.Map<PagedResult<CommodityDto>>(await _repository.GetPagedAsync(request.PageNumber, request.PageSize, request.Search));
    }
}
