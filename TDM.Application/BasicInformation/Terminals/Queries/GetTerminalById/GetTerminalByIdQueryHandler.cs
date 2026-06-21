using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Terminals.DTOs;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Terminals.Queries.GetTerminalById
{
    public class GetTerminalByIdQueryHandler : IRequestHandler<GetTerminalByIdQuery, TerminalDto>
    {
        private readonly IRepository<Terminal> _terminalRepository;
        private readonly IMapper _mapper;

        public GetTerminalByIdQueryHandler(IMapper mapper,
            IRepository<Terminal> terminalRepository)
        {
            _terminalRepository = terminalRepository;
            _mapper = mapper;
        }

        public async Task<TerminalDto> Handle(GetTerminalByIdQuery request, CancellationToken cancellationToken)
        {
            var terminal = await _terminalRepository.GetAsync(request.Id);

            if (terminal == null)
                throw new NotFoundException("Terminal");

            return _mapper.Map<TerminalDto>(terminal);

        }
    }
}
