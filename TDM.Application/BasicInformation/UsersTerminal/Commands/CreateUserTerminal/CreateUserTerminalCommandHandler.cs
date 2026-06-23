using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.UsersTerminal.Commands.CreateUserTerminal
{
    public class CreateUserTerminalCommandHandler : IRequestHandler<CreateUserTerminalCommand, Guid>
    {
        private readonly IUserTerminalRepository _userTerminalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserTerminalCommandHandler(IUnitOfWork unitOfWork
            , IUserTerminalRepository userTerminalRepository)
        {
            _unitOfWork = unitOfWork;
            _userTerminalRepository = userTerminalRepository;
        }

        public async Task<Guid> Handle(CreateUserTerminalCommand request, CancellationToken cancellationToken)
        {
            if (await _userTerminalRepository.ExistsByNationalId(request.UserNationalId))
                throw new Exception("This national id is already connected to a terminal.");

            var userTerminal = new UserTerminal(
                request.UserNationalId,
                request.TerminalId);

            await _userTerminalRepository.InsertAsync(userTerminal);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return userTerminal.Id;
        }
    }
}
