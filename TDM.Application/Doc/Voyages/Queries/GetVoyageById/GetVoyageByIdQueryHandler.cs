using AutoMapper;
using MediatR;
using TDM.Application.Doc.Voyages.DTOs;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.Voyages.Queries.GetVoyageById
{
    public class GetVoyageByIdQueryHandler : IRequestHandler<GetVoyageByIdQuery, VoyageDto>
    {
        private readonly IRepository<Voyage> _voyageRepository;
        private readonly IMapper _mapper;

        public GetVoyageByIdQueryHandler(IMapper mapper,
            IRepository<Voyage> voyageRepository)
        {
            _voyageRepository = voyageRepository;
            _mapper = mapper;
        }

        public async Task<VoyageDto> Handle(GetVoyageByIdQuery request, CancellationToken cancellationToken)
        {
            var voyage = await _voyageRepository.GetAsync(request.Id);

            if (voyage == null)
                throw new NotFoundException("Voyage");

            return _mapper.Map<VoyageDto>(voyage);

        }
    }
}
