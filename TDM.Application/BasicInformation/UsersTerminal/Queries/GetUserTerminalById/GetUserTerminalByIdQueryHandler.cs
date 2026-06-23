using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.UsersTerminal.DTOs;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.UsersTerminal.Queries.GetUserTerminalById
{
    public class GetUserTerminalByIdQueryHandler : IRequestHandler<GetUserTerminalByIdQuery, UserTerminalDto>
    {
        private readonly IUserTerminalRepository _userTerminalRepository;
        private readonly IMapper _mapper;

        public GetUserTerminalByIdQueryHandler(IMapper mapper,
            IUserTerminalRepository userTerminalRepository)
        {
            _userTerminalRepository = userTerminalRepository;
            _mapper = mapper;
        }

        public async Task<UserTerminalDto> Handle(GetUserTerminalByIdQuery request, CancellationToken cancellationToken)
        {
            var userTerminal = await _userTerminalRepository.GetAsync(request.Id);

            if (userTerminal == null)
                throw new NotFoundException("UserTerminal");

            return _mapper.Map<UserTerminalDto>(userTerminal);

        }
    }
}
