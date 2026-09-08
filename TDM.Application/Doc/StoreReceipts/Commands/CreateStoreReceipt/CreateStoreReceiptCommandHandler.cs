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
        private readonly IRepository<StoreReceiptGood> _storeReceiptGoodRepository;
        private readonly IRepository<StoreReceiptContainer> _storeReceiptContainerRepository;

        private readonly IUnitOfWork _unitOfWork;

        public CreateStoreReceiptCommandHandler(IUnitOfWork unitOfWork
            , IRepository<StoreReceiptHead> storeReceiptHeadRepository
            , IRepository<StoreReceiptGood> storeReceiptGoodRepository
            , IRepository<StoreReceiptContainer> storeReceiptContainerRepository)
        {
            _unitOfWork = unitOfWork;
            _storeReceiptHeadRepository = storeReceiptHeadRepository;
            _storeReceiptGoodRepository = storeReceiptGoodRepository;
            _storeReceiptContainerRepository = storeReceiptContainerRepository;
        }

        public async Task<Guid> Handle(CreateStoreReceiptCommand request, CancellationToken cancellationToken)
        {
            var receipt = new StoreReceiptHead(
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
                request.BillOfLadingId);

            foreach (var goodRequest in request.StoreReceiptGoods)
            {
                receipt.AddGood(
                    goodRequest.CommodityId,
                    goodRequest.PackageId,
                    goodRequest.BrandName,
                    goodRequest.NoBrandName,
                    goodRequest.PackNB,
                    goodRequest.GrossWeight,
                    goodRequest.NetWeight,
                    goodRequest.Volume,
                    goodRequest.Remark,
                    goodRequest.IsHeavy,
                    goodRequest.IsNonPalletized,
                    goodRequest.IsDamaged,
                    goodRequest.IsVoluminous,
                    goodRequest.IsDangerous,
                    goodRequest.DangerousNotNoticed,
                    goodRequest.DangerousCode,
                    goodRequest.Classification,
                    goodRequest.IgnitionTemperature,
                    goodRequest.IgnitionTemperatureUnit);
            }

            foreach (var containerRequest in request.StoreReceiptContainers)
            {
                var container = receipt.AddContainer(
                    containerRequest.ContainerId,
                    containerRequest.SealNumber,
                    containerRequest.Remark,
                    containerRequest.DangerousCode,
                    containerRequest.Classification,
                    containerRequest.IgnitionTemperature,
                    containerRequest.IgnitionTemperatureUnit);

                foreach (var goodRequest in containerRequest.StoreReceiptContainerGoods)
                {
                    container.AddGood(
                        goodRequest.CommodityId,
                        goodRequest.PackageId,
                        goodRequest.BrandName,
                        goodRequest.NoBrandName,
                        goodRequest.PackNB,
                        goodRequest.GrossWeight,
                        goodRequest.NetWeight,
                        goodRequest.Volume,
                        goodRequest.IsHeavy,
                        goodRequest.IsNonPalletized,
                        goodRequest.IsDamaged,
                        goodRequest.IsVoluminous,
                        goodRequest.IsDangerous,
                        goodRequest.DangerousNotNoticed);
                }
            }

            await _storeReceiptHeadRepository.InsertAsync(receipt);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return receipt.Id;
        }
    }

}
