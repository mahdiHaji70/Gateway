using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.Operation.WeightBridges.Commands.CreateWeightBridge
{
   
    public class CreateWeightBridgeCommandHandler : IRequestHandler<CreateWeightBridgeCommand, Guid>
    {
        private readonly IRepository<WeightBridge> _WeighBridgeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateWeightBridgeCommandHandler(IUnitOfWork unitOfWork
            , IRepository<WeightBridge> WeighBridgeRepository)
        {
            _unitOfWork = unitOfWork;
            _unitOfWork = unitOfWork;
            _WeighBridgeRepository = WeighBridgeRepository;
        }

        public async Task<Guid> Handle(CreateWeightBridgeCommand request, CancellationToken cancellationToken)
        {
            var WeighBridge = new WeightBridge(
                                          request.DeclarationId,
                                          request .GateId,
                                          request.Vehicle,
                                          request.GrossWeight,
                                          request.TareWeight,
                                           request.StartDate,
                                          request.EndDate

                                      );

            await _WeighBridgeRepository.InsertAsync(WeighBridge);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return WeighBridge.Id;
        }
    }
}
