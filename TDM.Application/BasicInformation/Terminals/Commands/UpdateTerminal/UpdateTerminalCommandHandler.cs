using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Terminals.Commands.UpdateTerminal
{
    public class UpdateTerminalCommandHandler : IRequestHandler<UpdateTerminalCommand, Guid>
    {
        private readonly IRepository<Terminal> _terminalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTerminalCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Terminal> terminalRepository)
        {
            _unitOfWork = unitOfWork;
            _terminalRepository = terminalRepository;
        }

        public async Task<Guid> Handle(UpdateTerminalCommand request, CancellationToken cancellationToken)
        {
            var terminal = await _terminalRepository.GetAsync(request.Id);

            if (terminal == null)
                throw new Exception("Terminal not found");

            terminal.Update(request.Code, request.Name, request.PortCode, request.Username, request.Password, request.IsActive);

            _terminalRepository.Update(terminal);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return terminal.Id;
        }
    }
}
