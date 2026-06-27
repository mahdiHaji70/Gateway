using AutoMapper;
using MediatR;

using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Application.Operation.Gates.DTOs;
using TDM.Domain.Entities;

namespace TDM.Application.Operation.Gates.Queries.GetGateById
{
  
    public class GetGateByIdQueryHandler : IRequestHandler<GetGateByIdQuery, GateDto>
    {
        private readonly IRepository<Gate> _gateRepository;
        private readonly IMapper _mapper;

        public GetGateByIdQueryHandler(IMapper mapper,
            IRepository<Gate> gateRepository)
        {
            _gateRepository = gateRepository;
            _mapper = mapper;
        }

        public async Task<GateDto> Handle(GetGateByIdQuery request, CancellationToken cancellationToken)
        {
            var Gate = await _gateRepository.GetAsync(request.Id);

            if (Gate == null)
                throw new NotFoundException("Gate");

            return _mapper.Map<GateDto>(Gate);

        }

    }
}
