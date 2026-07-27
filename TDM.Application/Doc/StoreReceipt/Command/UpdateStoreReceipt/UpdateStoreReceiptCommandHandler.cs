using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Declarations.Commands.UpdateDeclaration;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.StoreReceipt.Command.UpdateStoreReceipt
{
   
    public class UpdateStoreReceiptCommandHandler : IRequestHandler<UpdateStoreReceiptCommand, Guid>
    {
      
        private readonly IRepository<StoreReceiptHead> _storeReceiptHeadRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStoreReceiptCommandHandler(IUnitOfWork unitOfWork
            , IRepository<StoreReceiptHead> storeReceiptHeadRepository)
        {
            _unitOfWork = unitOfWork;
            _storeReceiptHeadRepository = storeReceiptHeadRepository;
        }
        public async Task<Guid> Handle(UpdateStoreReceiptCommand request, CancellationToken cancellationToken)
        {
            var storeReceiptHead = await _storeReceiptHeadRepository.GetAsync(request.Id);

            if (storeReceiptHead == null)
                throw new Exception("storeReceiptHead not found");

            storeReceiptHead.Update(   request.TerminalCode,
                                       request.IPASStoreReceiptNo,
                                       request.IssueDate,
                                       request.ConsigneeId,
                                       request.ConsigneeRepId,
                                       request.CargoTypeId,
                                       request.FirstDischargeDate,
                                       request.CreatorId,
                                       request.TrafficId,
                                       request.StoreReceiptStateId,
                                       request.RequestId,
                                       request.VoyageNoticeNo,
                                       request.ArrivalTypeId,
                                       request.DeclarationId,
                                       request.BillOfLadingId
                                   );

            _storeReceiptHeadRepository.Update(storeReceiptHead);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return storeReceiptHead.Id;
        }
    }
}
