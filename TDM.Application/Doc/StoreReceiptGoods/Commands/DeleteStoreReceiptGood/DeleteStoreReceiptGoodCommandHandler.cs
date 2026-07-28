using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.StoreReceiptGoods.Commands.DeleteStoreReceiptGood
{
    public class DeleteStoreReceiptGoodCommandHandler : IRequestHandler<DeleteStoreReceiptGoodCommand, bool>
    {
        private readonly IRepository<StoreReceiptGood> _storeReceiptGoodRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStoreReceiptGoodCommandHandler(IUnitOfWork unitOfWork
            , IRepository<StoreReceiptGood> storeReceiptGoodRepository)
        {
            _unitOfWork = unitOfWork;
            _storeReceiptGoodRepository = storeReceiptGoodRepository;
        }

        public async Task<bool> Handle(DeleteStoreReceiptGoodCommand request, CancellationToken cancellationToken)
        {
            var StoreReceiptGood = await _storeReceiptGoodRepository.GetAsync(request.Id);

            if (StoreReceiptGood == null)
                throw new Exception("storeReceiptGood not found");

            _storeReceiptGoodRepository.Delete(StoreReceiptGood);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
