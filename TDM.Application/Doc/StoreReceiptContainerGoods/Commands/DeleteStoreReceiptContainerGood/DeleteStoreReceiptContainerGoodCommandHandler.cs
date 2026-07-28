using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;

using TDM.Domain.Entities;

namespace TDM.Application.Doc.StoreReceiptContainerContainerGoods.Commands.DeleteStoreReceiptContainerContainerGood
{
    public class DeleteStoreReceiptContainerGoodCommandHandler : IRequestHandler<DeleteStoreReceiptContainerGoodCommand, bool>
    {
        private readonly IRepository<StoreReceiptContainerGood> _storeReceiptContainerGoodRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStoreReceiptContainerGoodCommandHandler(IUnitOfWork unitOfWork
            , IRepository<StoreReceiptContainerGood> storeReceiptContainerGoodRepository)
        {
            _unitOfWork = unitOfWork;
            _storeReceiptContainerGoodRepository = storeReceiptContainerGoodRepository;
        }

        public async Task<bool> Handle(DeleteStoreReceiptContainerGoodCommand request, CancellationToken cancellationToken)
        {
            var StoreReceiptContainerGood = await _storeReceiptContainerGoodRepository.GetAsync(request.Id);

            if (StoreReceiptContainerGood == null)
                throw new Exception("storeReceiptContainerGood not found");

            _storeReceiptContainerGoodRepository.Delete(StoreReceiptContainerGood);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
