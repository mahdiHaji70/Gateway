using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.StoreReceiptContainers.Commands.UpdateStoreReceiptContainer
{
   
    public class UpdateStoreReceiptContainerCommandHandler : IRequestHandler<UpdateStoreReceiptContainerCommand, Guid>
    {
        private readonly IRepository<StoreReceiptContainer> _StoreReceiptContainerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStoreReceiptContainerCommandHandler(IUnitOfWork unitOfWork
            , IRepository<StoreReceiptContainer> StoreReceiptContainerRepository)
        {
            _unitOfWork = unitOfWork;
            _StoreReceiptContainerRepository = StoreReceiptContainerRepository;
        }

        public async Task<Guid> Handle(UpdateStoreReceiptContainerCommand request, CancellationToken cancellationToken)
        {
            var StoreReceiptContainer = await _StoreReceiptContainerRepository.GetAsync(request.Id);

            if (StoreReceiptContainer == null)
                throw new Exception("storeReceiptContainer not found");

            StoreReceiptContainer.Update(
                request.StoreReceiptHeadId,
                                            request.ContainerId,
                                            request.SealNumber,
                                            request.Remark,
                                            request.DangerousCode,
                                            request.Classification,
                                            request.IgnitionTemperature,
                                            request.IgnitionTemperatureUnit);

            _StoreReceiptContainerRepository.Update(StoreReceiptContainer);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return StoreReceiptContainer.Id;
        }
    }
}
