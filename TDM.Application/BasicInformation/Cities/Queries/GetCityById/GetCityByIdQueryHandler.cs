using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Cities.DTOs;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Cities.Queries.GetCityById
{
    public class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQuery, CityDto>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public GetCityByIdQueryHandler(IMapper mapper,
            ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<CityDto> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            var city = await _cityRepository.GetAsync(request.Id);

            if (city == null)
                throw new NotFoundException("City");

            return _mapper.Map<CityDto>(city);

        }
    }
}
