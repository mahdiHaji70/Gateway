using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Countries.DTOs;
using TDM.Application.BasicInformation.Countries.Queries.GetCountries;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Countries.Queries.GetCountrys
{
    public class GetCountrysQueryHandler : IRequestHandler<GetCountriesQuery, PagedResult<CountryDto>>
    {
        private readonly IRepository<Country> _countryRepository;
        private readonly IMapper _mapper;

        public GetCountrysQueryHandler(IMapper mapper,
            IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CountryDto>> Handle(
        GetCountriesQuery request,
        CancellationToken cancellationToken)
        {
            var countries = await _countryRepository.GetPagedAsync(request.PageNumber, request.PageSize);

            return _mapper.Map<PagedResult<CountryDto>>(countries);
        }
    }
}
