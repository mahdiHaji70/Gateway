using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Cities.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Cities.Queries.GetCityLookup
{
    public class GetCityLookupQueryHandler : IRequestHandler<GetCityLookupQuery, PagedResult<CityDto>>
    {
        private readonly ICityRepository _repository;
        private readonly IMapper _mapper;

        public GetCityLookupQueryHandler(ICityRepository repository, IMapper mapper)
        { _repository = repository; _mapper = mapper; }

        public async Task<PagedResult<CityDto>> Handle(GetCityLookupQuery request, CancellationToken cancellationToken)
            => _mapper.Map<PagedResult<CityDto>>(await _repository.GetPagedAsync(request.PageNumber, request.PageSize, request.Search));
    }
}
