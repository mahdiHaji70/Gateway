using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.UsersTerminal.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.UsersTerminal.Queries.GetUserTerminalLookup
{
    public class GetUserTerminalLookupQueryHandler : IRequestHandler<GetUserTerminalLookupQuery, PagedResult<UserTerminalDto>>
    {
        private readonly IUserTerminalRepository _repository;
        private readonly IMapper _mapper;

        public GetUserTerminalLookupQueryHandler(IUserTerminalRepository repository, IMapper mapper)
        { _repository = repository; _mapper = mapper; }

        public async Task<PagedResult<UserTerminalDto>> Handle(GetUserTerminalLookupQuery request, CancellationToken cancellationToken)
            => _mapper.Map<PagedResult<UserTerminalDto>>(await _repository.GetPagedAsync(request.PageNumber, request.PageSize, request.Search));
    }
}
