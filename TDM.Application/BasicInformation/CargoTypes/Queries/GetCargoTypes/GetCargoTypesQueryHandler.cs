using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.CargoTypes.DTOs;
using TDM.Application.BasicInformation.Cities.DTOs;
using TDM.Application.BasicInformation.Cities.Queries.GetCities;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.CargoTypes.Queries.GetCargoTypes
{
    public class GetCargoTypesQueryHandler : IRequestHandler<GetCargoTypesQuery, PagedResult<CargoTypeDto>>
    {
        private readonly ICargoTypeRepository _cargoTypeRepository;
        private readonly IMapper _mapper;

        public GetCargoTypesQueryHandler(IMapper mapper,
            ICargoTypeRepository cargoTypeRepository)
        {
            _cargoTypeRepository = cargoTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CargoTypeDto>> Handle(
        GetCargoTypesQuery request,
        CancellationToken cancellationToken)
        {
            var cargoTypes = await _cargoTypeRepository.GetPagedAsync(request.PageNumber, request.PageSize);

            return _mapper.Map<PagedResult<CargoTypeDto>>(cargoTypes);
        }
    }
}
