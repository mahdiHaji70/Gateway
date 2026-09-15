using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.StoreReceiptContainers.Commands.DeleteStoreReceiptContainer
{
   
    public class DeleteStoreReceiptContainerCommandHandler : IRequestHandler<DeleteStoreReceiptContainerCommand, bool>
    {
        private readonly IRepository<StoreReceiptContainer> _storeReceiptContainerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStoreReceiptContainerCommandHandler(IUnitOfWork unitOfWork
            , IRepository<StoreReceiptContainer> StoreReceiptContainerRepository)
        {
            _unitOfWork = unitOfWork;
            _storeReceiptContainerRepository = StoreReceiptContainerRepository;
        }

        public async Task<bool> Handle(DeleteStoreReceiptContainerCommand request, CancellationToken cancellationToken)
        {
            var StoreReceiptContainer = await _storeReceiptContainerRepository.GetAsync(request.Id);

            if (StoreReceiptContainer == null)
                throw new Exception("StoreReceiptContainer not found");

            _storeReceiptContainerRepository.Delete(StoreReceiptContainer);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
