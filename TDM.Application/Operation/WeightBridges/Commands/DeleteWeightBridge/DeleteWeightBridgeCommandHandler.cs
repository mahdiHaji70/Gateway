using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Operation.WeightBridges.Commands.DeleteWeightBridge;
using TDM.Domain.Entities;

namespace TDM.Application.Operation.WeightBridges.Commands.DeleteWeightBridge
{
    public class DeleteWeightBridgeCommandHandler : IRequestHandler<DeleteWeightBridgeCommand, bool>
    {
        private readonly IRepository<WeightBridge> _weightBridgeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteWeightBridgeCommandHandler(IUnitOfWork unitOfWork
            , IRepository<WeightBridge> weightBridgeRepository)
        {
            _unitOfWork = unitOfWork;
            _weightBridgeRepository = weightBridgeRepository;
        }

        public async Task<bool> Handle(DeleteWeightBridgeCommand request, CancellationToken cancellationToken)
        {
            var weightBridge = await _weightBridgeRepository.GetAsync(request.Id);

            if (weightBridge == null)
                throw new Exception("WeighBridge not found");

            _weightBridgeRepository.Delete(weightBridge);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
