using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.UsersTerminal.Commands.UpdateUserTerminal
{
    public class UpdateUserTerminalCommandHandler : IRequestHandler<UpdateUserTerminalCommand, Guid>
    {
        private readonly IUserTerminalRepository _userTerminalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserTerminalCommandHandler(IUnitOfWork unitOfWork
            , IUserTerminalRepository userTerminalRepository)
        {
            _unitOfWork = unitOfWork;
            _userTerminalRepository = userTerminalRepository;
        }

        public async Task<Guid> Handle(UpdateUserTerminalCommand request, CancellationToken cancellationToken)
        {
            var userTerminal = await _userTerminalRepository.GetAsync(request.Id);

            if (userTerminal == null)
                throw new Exception("UserTerminal not found");

            if (await _userTerminalRepository.ExistsByNationalId(request.UserNationalId))
                throw new Exception("This national id is already connected to a terminal.");

            userTerminal.Update(request.UserNationalId, request.TerminalId);

            _userTerminalRepository.Update(userTerminal);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return userTerminal.Id;
        }
    }
}
