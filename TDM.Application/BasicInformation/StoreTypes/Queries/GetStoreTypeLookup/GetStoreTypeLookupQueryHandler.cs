using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.StoreTypes.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.StoreTypes.Queries.GetStoreTypeLookup
{
    public class GetStoreTypeLookupQueryHandler : IRequestHandler<GetStoreTypeLookupQuery, PagedResult<StoreTypeDto>>
    {
        private readonly IStoreTypeRepository _repository;
        private readonly IMapper _mapper;

        public GetStoreTypeLookupQueryHandler(IStoreTypeRepository repository, IMapper mapper)
        { _repository = repository; _mapper = mapper; }

        public async Task<PagedResult<StoreTypeDto>> Handle(GetStoreTypeLookupQuery request, CancellationToken cancellationToken)
            => _mapper.Map<PagedResult<StoreTypeDto>>(await _repository.GetPagedAsync(request.PageNumber, request.PageSize, request.Search));
    }
}
