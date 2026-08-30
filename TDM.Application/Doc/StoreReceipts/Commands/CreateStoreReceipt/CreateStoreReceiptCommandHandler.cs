using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.StoreReceipt.Command.CreateStoreReceipt;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.StoreReceipts.Commands.CreateStoreReceipt
{

    public class CreateStoreReceiptCommandHandler : IRequestHandler<CreateStoreReceiptCommand, Guid>
    {
        private readonly IRepository<StoreReceiptHead> _storeReceiptHeadRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateStoreReceiptCommandHandler(IUnitOfWork unitOfWork
            , IRepository<StoreReceiptHead> storeReceiptHeadRepository)
        {
            _unitOfWork = unitOfWork;
            _storeReceiptHeadRepository = storeReceiptHeadRepository;
        }

        public async Task<Guid> Handle(CreateStoreReceiptCommand request, CancellationToken cancellationToken)
        {
            var storeReceiptHead = new StoreReceiptHead(
                                        request.TerminalCode,
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
            foreach (var itemGood in request.StoreReceiptGoods)
            {
                var storeReceiptGood = new StoreReceiptGood(
                                                       itemGood.StoreReceiptHeadId,
                                                       itemGood.CommodityId,
                                                       itemGood.PackageId,
                                                       itemGood.BrandName,
                                                       itemGood.NoBrandName,
                                                       itemGood.PackNB,
                                                       itemGood.GrossWeight,
                                                       itemGood.NetWeight,
                                                       itemGood.Volume,
                                                       itemGood.Remark,
                                                       itemGood.IsHeavy,
                                                       itemGood.IsNonPalletized,
                                                       itemGood.IsDamaged,
                                                       itemGood.IsVoluminous,
                                                       itemGood.IsDangerous,
                                                       itemGood.DangerousNotNoticed,
                                                       itemGood.DangerousCode,
                                                       itemGood.Classification,
                                                       itemGood.IgnitionTemperature,
                                                       itemGood.IgnitionTemperatureUnit
                                                   );
            }







            await _storeReceiptHeadRepository.InsertAsync(storeReceiptHead);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return storeReceiptHead.Id;
        }
    }

}
