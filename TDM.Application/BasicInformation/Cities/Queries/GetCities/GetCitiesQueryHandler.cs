using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Cities.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Cities.Queries.GetCities
{
    public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, PagedResult<CityDto>>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public GetCitiesQueryHandler(IMapper mapper,
            ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CityDto>> Handle(
        GetCitiesQuery request,
        CancellationToken cancellationToken)
        {
            var countries = await _cityRepository.GetPagedAsync(request.PageNumber, request.PageSize);

            return _mapper.Map<PagedResult<CityDto>>(countries);
        }
    }
}
