using AutoMapper;
using MediatR;
using TDM.Application.Doc.Voyages.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.Doc.Voyages.Queries.GetVoyageLookup
{
    public class GetVoyageLookupQueryHandler : IRequestHandler<GetVoyageLookupQuery, PagedResult<VoyageDto>>
    {
        private readonly IVoyageRepository _repository;
        private readonly IMapper _mapper;

        public GetVoyageLookupQueryHandler(IVoyageRepository repository, IMapper mapper)
        { _repository = repository; _mapper = mapper; }

        public async Task<PagedResult<VoyageDto>> Handle(GetVoyageLookupQuery request, CancellationToken cancellationToken)
            => _mapper.Map<PagedResult<VoyageDto>>(await _repository.GetPagedAsync(request.PageNumber, request.PageSize, request.Search));
    }
}
