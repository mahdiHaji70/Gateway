using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Countries.DTOs;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Countries.Queries.GetCountryById
{
    public class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, CountryDto>
    {
        private readonly IRepository<Country> _countryRepository;
        private readonly IMapper _mapper;

        public GetCountryByIdQueryHandler(IMapper mapper,
            IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<CountryDto> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
            var country = await _countryRepository.GetAsync(request.Id);

            if (country == null)
                throw new NotFoundException("Country");

            return _mapper.Map<CountryDto>(country);

        }
    }
}
