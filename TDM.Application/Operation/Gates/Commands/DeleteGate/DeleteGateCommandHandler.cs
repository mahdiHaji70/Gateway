using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Operation.Gates.Commands.DeleteGate;
using TDM.Domain.Entities;

namespace TDM.Application.Operation.Gates.Commands.DeleteGate
{
    
    public class DeleteGateCommandHandler : IRequestHandler<DeleteGateCommand, bool>
    {
        private readonly IRepository<Gate> _gateRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteGateCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Gate> gateRepository)
        {
            _unitOfWork = unitOfWork;
            _gateRepository = gateRepository;
        }

        public async Task<bool> Handle(DeleteGateCommand request, CancellationToken cancellationToken)
        {
            var gate = await _gateRepository.GetAsync(request.Id);

            if (gate == null)
                throw new Exception("Gate not found");

            _gateRepository.Delete(gate);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
