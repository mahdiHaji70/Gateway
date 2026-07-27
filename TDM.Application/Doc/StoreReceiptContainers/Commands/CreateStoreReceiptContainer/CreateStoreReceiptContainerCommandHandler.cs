using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.StoreReceiptContainers.Commands.CreateStoreReceiptContainer
{

    public class CreateStoreReceiptContainerCommandHandler : IRequestHandler<CreateStoreReceiptContainerCommand, Guid>
    {
        private readonly IRepository<StoreReceiptContainer> _StoreReceiptContainerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateStoreReceiptContainerCommandHandler(IUnitOfWork unitOfWork
            , IRepository<StoreReceiptContainer> StoreReceiptContainerRepository)
        {
            _unitOfWork = unitOfWork;
            _StoreReceiptContainerRepository = StoreReceiptContainerRepository;
        }

        public async Task<Guid> Handle(CreateStoreReceiptContainerCommand request, CancellationToken cancellationToken)
        {
            var storeReceiptContainer = new StoreReceiptContainer(
                                            request.StoreReceiptHeadId,
                                            request.ContainerId,
                                            request.SealNumber,
                                            request.Remark,
                                            request.DangerousCode,
                                            request.Classification,
                                            request.IgnitionTemperature,
                                            request.IgnitionTemperatureUnit);

            await _StoreReceiptContainerRepository.InsertAsync(storeReceiptContainer);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return storeReceiptContainer.Id;
        }
    }
}
