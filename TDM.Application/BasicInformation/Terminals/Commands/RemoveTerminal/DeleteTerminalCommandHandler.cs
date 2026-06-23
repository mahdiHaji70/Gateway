using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Terminals.Commands.RemoveTerminal
{
    public class DeleteTerminalCommandHandler : IRequestHandler<DeleteTerminalCommand, bool>
    {
        private readonly IRepository<Terminal> _terminalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTerminalCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Terminal> terminalRepository)
        {
            _unitOfWork = unitOfWork;
            _terminalRepository = terminalRepository;
        }

        public async Task<bool> Handle(DeleteTerminalCommand request, CancellationToken cancellationToken)
        {
            var terminal = await _terminalRepository.GetAsync(request.Id);

            if (terminal == null)
                throw new Exception("Terminal not found");

            _terminalRepository.Delete(terminal);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
