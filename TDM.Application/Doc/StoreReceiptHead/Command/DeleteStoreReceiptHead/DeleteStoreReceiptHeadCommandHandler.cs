using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Declarations.Commands.RemoveDeclaration;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.StoreReceipt.Command.DeleteStoreReceipt
{
    
    public class DeleteStoreReceiptHeadCommandHandler : IRequestHandler<DeleteStoreReceiptHeadCommand, bool>
    {
      
        private readonly IRepository<StoreReceiptHead> _storeReceiptHeadRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStoreReceiptHeadCommandHandler(IUnitOfWork unitOfWork
            , IRepository<StoreReceiptHead> storeReceiptHeadRepository)
        {
            _unitOfWork = unitOfWork;
            _storeReceiptHeadRepository = storeReceiptHeadRepository;
        }

        public async Task<bool> Handle(DeleteStoreReceiptHeadCommand request, CancellationToken cancellationToken)
        {
            var storeReceiptHead = await _storeReceiptHeadRepository.GetAsync(request.Id);

            if (storeReceiptHead == null)
                throw new Exception("storeReceiptHead not found");

            _storeReceiptHeadRepository.Delete(storeReceiptHead);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
