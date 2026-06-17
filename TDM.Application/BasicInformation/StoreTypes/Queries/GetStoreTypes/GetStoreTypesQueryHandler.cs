using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.StoreTypes.DTOs;
using TDM.Application.BasicInformation.StoreTypes.Queries.GetStoreTypes;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.StoreTypes.Queries.GetStoreTypes
{
    public class GetStoreTypesQueryHandler : IRequestHandler<GetStoreTypesQuery, PagedResult<StoreTypeDto>>
    {
        private readonly IStoreTypeRepository _storeTypeRepository;
        private readonly IMapper _mapper;

        public GetStoreTypesQueryHandler(IMapper mapper,
            IStoreTypeRepository storeTypeRepository)
        {
            _storeTypeRepository = storeTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<StoreTypeDto>> Handle(
        GetStoreTypesQuery request,
        CancellationToken cancellationToken)
        {
            var storeTypes = await _storeTypeRepository.GetPagedAsync(request.PageNumber, request.PageSize);

            return _mapper.Map<PagedResult<StoreTypeDto>>(storeTypes);
        }
    }
}
