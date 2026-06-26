using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.Operation.Gate.Commands.CreateGate
{
    public class CreateGateCommandHandler : IRequestHandler<CreateGateCommand, Guid>
    {
        private readonly IRepository<TDM.Domain.Entities.Gate> _GateRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateGateCommandHandler(IUnitOfWork unitOfWork
            , IRepository<TDM.Domain.Entities.Gate> GateRepository)
        {
            _unitOfWork = unitOfWork;
            _unitOfWork = unitOfWork;
            _GateRepository = GateRepository;
        }

        public async Task<Guid> Handle(CreateGateCommand request, CancellationToken cancellationToken)
        {
            var Gate = new TDM.Domain.Entities.Gate(
                                          request.DeclarationId,
                                          request.Vehicle,
                                          request.ContainerId,
                                          request.EnterDate,
                                          request.ExitDate
                                      
                                      );

            await _GateRepository.InsertAsync(Gate);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Gate.Id;
        }
    }
}
