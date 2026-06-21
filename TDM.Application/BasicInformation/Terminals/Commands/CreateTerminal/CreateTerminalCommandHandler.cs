using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Terminals.Commands.CreateTerminal
{
    public class CreateTerminalCommandHandler : IRequestHandler<CreateTerminalCommand, Guid>
    {
        private readonly IRepository<Terminal> _terminalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTerminalCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Terminal> terminalRepository)
        {
            _unitOfWork = unitOfWork;
            _terminalRepository = terminalRepository;
        }

        public async Task<Guid> Handle(CreateTerminalCommand request, CancellationToken cancellationToken)
        {
            var terminal = new Terminal(
                request.Code,
                request.Name,
                request.PortCode,
                request.Username,
                request.Password,
                request.IsActive);

            await _terminalRepository.InsertAsync(terminal);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return terminal.Id;
        }
    }
}
