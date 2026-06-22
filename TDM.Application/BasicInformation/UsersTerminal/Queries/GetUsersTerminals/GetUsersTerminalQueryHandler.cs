using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.UsersTerminal.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.UsersTerminal.Queries.GetUsersTerminal
{
    public class GetUsersTerminalQueryHandler : IRequestHandler<GetUsersTerminalQuery, PagedResult<UserTerminalDto>>
    {
        private readonly IUserTerminalRepository _userTerminalRepository;
        private readonly IMapper _mapper;

        public GetUsersTerminalQueryHandler(IMapper mapper,
            IUserTerminalRepository userTerminalRepository)
        {
            _userTerminalRepository = userTerminalRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<UserTerminalDto>> Handle(
        GetUsersTerminalQuery request,
        CancellationToken cancellationToken)
        {
            var usersTerminal = await _userTerminalRepository.GetPagedAsync(request.PageNumber, request.PageSize);

            return _mapper.Map<PagedResult<UserTerminalDto>>(usersTerminal);
        }
    }
}
