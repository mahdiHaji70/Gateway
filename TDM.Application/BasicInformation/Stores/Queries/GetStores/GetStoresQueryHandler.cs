using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Stores.DTOs;
using TDM.Application.BasicInformation.Stores.Queries.GetStores;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Stores.Queries.GetStores
{
    public class GetStoresQueryHandler : IRequestHandler<GetStoresQuery, PagedResult<StoreDto>>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public GetStoresQueryHandler(IMapper mapper,
            IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<StoreDto>> Handle(
        GetStoresQuery request,
        CancellationToken cancellationToken)
        {
            var Stores = await _storeRepository.GetPagedAsync(request.PageNumber, request.PageSize);

            return _mapper.Map<PagedResult<StoreDto>>(Stores);
        }
    }
}
