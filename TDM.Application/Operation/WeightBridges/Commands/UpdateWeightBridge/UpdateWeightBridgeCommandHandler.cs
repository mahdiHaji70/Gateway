using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Operation.WeightBridges.Commands.UpdateWeightBridge;
using TDM.Domain.Entities;

namespace TDM.Application.Operation.WeightBridges.Commands.UpdateWeightBridge
{
    public class UpdateWeightBridgeCommandHandler : IRequestHandler<UpdateWeightBridgeCommand, Guid>
    {

        private readonly IRepository<WeightBridge> _WeightBridgeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateWeightBridgeCommandHandler(IUnitOfWork unitOfWork
            , IRepository<WeightBridge> WeightBridgeRepository)
        {
            _unitOfWork = unitOfWork;
            _WeightBridgeRepository = WeightBridgeRepository;
        }

        public async Task<Guid> Handle(UpdateWeightBridgeCommand request, CancellationToken cancellationToken)
        {
            var WeightBridge = await _WeightBridgeRepository.GetAsync(request.Id);

            if (WeightBridge == null)
                throw new Exception("WeightBridge not found");

            WeightBridge.Update(
                                          request.DeclarationId,
                                          request.GateId,
                                          request.Vehicle,
                                          request.GrossWeight,
                                          request.TareWeight,
                                          request.StartDate,
                                          request.EndDate
                                   );

            _WeightBridgeRepository.Update(WeightBridge);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return WeightBridge.Id;
        }
    }

    }
