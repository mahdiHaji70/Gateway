using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.StoreTypes.DTOs;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.StoreTypes.Queries.GetStoreTypeById
{
    
    public class GetStoreTypeByIdQueryHandler : IRequestHandler<GetStoreTypeByIdQuery, StoreTypeDto>
    {
        private readonly IRepository<StoreType> _storeTypeRepository;
        private readonly IMapper _mapper;

        public GetStoreTypeByIdQueryHandler(IMapper mapper,
            IRepository<StoreType> storeTypeRepository)
        {
            _storeTypeRepository = storeTypeRepository;
            _mapper = mapper;
        }

        public async Task<StoreTypeDto> Handle(GetStoreTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var storeType = await _storeTypeRepository.GetAsync(request.Id);

            if (storeType == null)
                throw new NotFoundException("StoreType");

            return _mapper.Map<StoreTypeDto>(storeType);

        }

    }
}
