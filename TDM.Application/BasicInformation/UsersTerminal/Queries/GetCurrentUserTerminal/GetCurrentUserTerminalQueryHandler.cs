using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.UsersTerminal.DTOs;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.UsersTerminal.Queries.GetCurrentUserTerminal
{
    public class GetCurrentUserTerminalQueryHandler : IRequestHandler<GetCurrentUserTerminalQuery, UserTerminalDto>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserTerminalRepository _userTerminalRepository;
        private readonly IMapper _mapper;

        public GetCurrentUserTerminalQueryHandler(IMapper mapper,
            ICurrentUserService currentUserService,
            IUserTerminalRepository userTerminalRepository)
        {
            _currentUserService = currentUserService;
            _userTerminalRepository = userTerminalRepository;
            _mapper = mapper;
        }

        public async Task<UserTerminalDto> Handle(GetCurrentUserTerminalQuery request, CancellationToken cancellationToken)
        {            
            var userTerminal = await _userTerminalRepository.GetByNationalId(_currentUserService.NationalId!);

            if (userTerminal == null)
                throw new NotFoundException("UserTerminal");

            return _mapper.Map<UserTerminalDto>(userTerminal);

        }
    }
}
