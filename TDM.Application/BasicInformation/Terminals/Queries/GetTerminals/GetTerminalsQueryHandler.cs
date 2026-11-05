using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Terminals.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Terminals.Queries.GetTerminals
{
    public class GetTerminalsQueryHandler : IRequestHandler<GetTerminalsQuery, PagedResult<TerminalDto>>
    {
        private readonly ITerminalRepository _terminalRepository;
        private readonly IMapper _mapper;

        public GetTerminalsQueryHandler(IMapper mapper,
            ITerminalRepository terminalRepository)
        {
            _terminalRepository = terminalRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TerminalDto>> Handle(
        GetTerminalsQuery request,
        CancellationToken cancellationToken)
        {
            var terminals = await _terminalRepository.GetPagedAsync(request.PageNumber, request.PageSize, request.Search);

            return _mapper.Map<PagedResult<TerminalDto>>(terminals);
        }
    }
}
