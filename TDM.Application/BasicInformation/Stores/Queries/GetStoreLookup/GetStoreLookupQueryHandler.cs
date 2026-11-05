using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Stores.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Stores.Queries.GetStoreLookup
{
    public class GetStoreLookupQueryHandler : IRequestHandler<GetStoreLookupQuery, PagedResult<StoreDto>>
    {
        private readonly IStoreRepository _repository;
        private readonly IMapper _mapper;

        public GetStoreLookupQueryHandler(IStoreRepository repository, IMapper mapper)
        { _repository = repository; _mapper = mapper; }

        public async Task<PagedResult<StoreDto>> Handle(GetStoreLookupQuery request, CancellationToken cancellationToken)
            => _mapper.Map<PagedResult<StoreDto>>(await _repository.GetPagedAsync(request.PageNumber, request.PageSize, request.Search));
    }
}
