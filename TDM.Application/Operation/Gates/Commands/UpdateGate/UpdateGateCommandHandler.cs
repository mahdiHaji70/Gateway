using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Operation.Gates.Commands.UpdateGate;
using TDM.Domain.Entities;

namespace TDM.Application.Operation.Gates.Commands.UpdateGate
{
  
    public class UpdateGateCommandHandler : IRequestHandler<UpdateGateCommand, Guid>
    {

        private readonly IRepository<Gate> _gateRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateGateCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Gate> gateRepository)
        {
            _unitOfWork = unitOfWork;
            _gateRepository = gateRepository;
        }

        public async Task<Guid> Handle(UpdateGateCommand request, CancellationToken cancellationToken)
        {
            var Gate = await _gateRepository.GetAsync(request.Id);

            if (Gate == null)
                throw new Exception("Gate not found");

            Gate.Update(
                                          request.DeclarationId,
                                          request.Vehicle,
                                          request.ContainerId,
                                          request.EnterDate,
                                          request.ExitDate
                                   );

            _gateRepository.Update(Gate);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Gate.Id;
        }
    }
}
