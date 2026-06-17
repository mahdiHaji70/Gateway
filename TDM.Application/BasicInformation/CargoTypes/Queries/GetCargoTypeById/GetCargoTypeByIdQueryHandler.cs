using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.CargoTypes.DTOs;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.CargoTypes.Queries.GetCargoTypeById
{
    public class GetCargoTypeByIdQueryHandler:IRequestHandler<GetCargoTypeByIdQuery, CargoTypeDto>
    {
        private readonly IRepository<CargoType> _cargoTypeRepository;
        private readonly IMapper _mapper;

        public GetCargoTypeByIdQueryHandler(IMapper mapper,
            IRepository<CargoType> cargoTypeRepository)
        {
            _cargoTypeRepository = cargoTypeRepository;
            _mapper = mapper;
        }

        public async Task<CargoTypeDto> Handle(GetCargoTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var cargoType = await _cargoTypeRepository.GetAsync(request.Id);

            if (cargoType == null)
                throw new NotFoundException("CargoType");

            return _mapper.Map<CargoTypeDto>(cargoType);

        }
    
}
}
