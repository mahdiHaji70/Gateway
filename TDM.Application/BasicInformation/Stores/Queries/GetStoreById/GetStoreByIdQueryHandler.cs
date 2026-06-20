using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Stores.DTOs;
using TDM.Application.BasicInformation.Stores.Queries.GetStoreById;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Stores.Queries.GetStoreById
{
    public class GetStoreByIdQueryHandler : IRequestHandler<GetStoreByIdQuery, StoreDto>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public GetStoreByIdQueryHandler(IMapper mapper,
            IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<StoreDto> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
        {
            var store = await _storeRepository.GetAsync(request.Id);

            if (store == null)
                throw new NotFoundException("Store");

            return _mapper.Map<StoreDto>(store);

        }

    }
}
