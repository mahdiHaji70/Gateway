using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Countries.DTOs;
using TDM.Application.BasicInformation.Countries.Queries.GetCountries;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Countries.Queries.GetCountrys
{
    public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, PagedResult<CountryDto>>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public GetCountriesQueryHandler(IMapper mapper,
            ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CountryDto>> Handle(
        GetCountriesQuery request,
        CancellationToken cancellationToken)
        {
            var countries = await _countryRepository.GetPagedAsync(request.PageNumber, request.PageSize, request.Search);

            return _mapper.Map<PagedResult<CountryDto>>(countries);
        }
    }
}
