using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Terminals.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Terminals.Queries.GetTerminalLookup
{
    public class GetTerminalLookupQueryHandler : IRequestHandler<GetTerminalLookupQuery, PagedResult<TerminalDto>>
    {
        private readonly ITerminalRepository _repository;
        private readonly IMapper _mapper;

        public GetTerminalLookupQueryHandler(ITerminalRepository repository, IMapper mapper)
        { _repository = repository; _mapper = mapper; }

        public async Task<PagedResult<TerminalDto>> Handle(GetTerminalLookupQuery request, CancellationToken cancellationToken)
            => _mapper.Map<PagedResult<TerminalDto>>(await _repository.GetPagedAsync(request.PageNumber, request.PageSize, request.Search));
    }
}
