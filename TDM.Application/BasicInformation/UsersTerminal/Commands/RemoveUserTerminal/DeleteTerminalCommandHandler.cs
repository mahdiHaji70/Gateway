using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.UsersTerminal.Commands.RemoveUserTerminal
{
    public class DeleteUserTerminalCommandHandler : IRequestHandler<DeleteUserTerminalCommand, bool>
    {
        private readonly IRepository<UserTerminal> _userTerminalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserTerminalCommandHandler(IUnitOfWork unitOfWork
            , IRepository<UserTerminal> userTerminalRepository)
        {
            _unitOfWork = unitOfWork;
            _userTerminalRepository = userTerminalRepository;
        }

        public async Task<bool> Handle(DeleteUserTerminalCommand request, CancellationToken cancellationToken)
        {
            var userTerminal = await _userTerminalRepository.GetAsync(request.Id);

            if (userTerminal == null)
                throw new Exception("UserTerminal not found");

            _userTerminalRepository.Delete(userTerminal);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
