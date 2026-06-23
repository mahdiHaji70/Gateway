using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.UsersTerminal.DTOs;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.UsersTerminal.Queries.GetUserTerminalByNationalId
{
    public class GetUserTerminalByNationalIdQueryHandler : IRequestHandler<GetUserTerminalByNationalIdQuery, UserTerminalDto>
    {
        private readonly IUserTerminalRepository _userTerminalRepository;
        private readonly IMapper _mapper;

        public GetUserTerminalByNationalIdQueryHandler(IMapper mapper,
            IUserTerminalRepository userTerminalRepository)
        {
            _userTerminalRepository = userTerminalRepository;
            _mapper = mapper;
        }

        public async Task<UserTerminalDto> Handle(GetUserTerminalByNationalIdQuery request, CancellationToken cancellationToken)
        {
            var userTerminal = await _userTerminalRepository.GetByNationalId(request.NationalId);

            if (userTerminal == null)
                throw new NotFoundException("UserTerminal");

            return _mapper.Map<UserTerminalDto>(userTerminal);

        }
    }
}
