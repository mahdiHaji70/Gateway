using AutoMapper;
using MediatR;
using TDM.Application.Doc.Voyages.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.Doc.Voyages.Queries.GetVoyages
{
    public class GetVoyagesQueryHandler : IRequestHandler<GetVoyagesQuery, PagedResult<VoyageDto>>
    {
        private readonly IVoyageRepository _voyageRepository;
        private readonly IMapper _mapper;

        public GetVoyagesQueryHandler(IMapper mapper,
            IVoyageRepository voyageRepository)
        {
            _voyageRepository = voyageRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<VoyageDto>> Handle(
        GetVoyagesQuery request,
        CancellationToken cancellationToken)
        {
            var voyages = await _voyageRepository.GetPagedAsync(request.PageNumber, request.PageSize, request.Search);

            return _mapper.Map<PagedResult<VoyageDto>>(voyages);
        }
    }
}
