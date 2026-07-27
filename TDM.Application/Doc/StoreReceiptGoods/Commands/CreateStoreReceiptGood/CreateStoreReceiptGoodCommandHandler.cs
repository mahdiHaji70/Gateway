using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.StoreReceiptGoods.Commands.CreateStoreReceiptGood
{
   
    public class CreateStoreReceiptGoodCommandHandler : IRequestHandler<CreateStoreReceiptGoodCommand, Guid>
    {
        private readonly IRepository<StoreReceiptGood> _storeReceiptGoodRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateStoreReceiptGoodCommandHandler(IUnitOfWork unitOfWork
            , IRepository<StoreReceiptGood> storeReceiptGoodRepository)
        {
            _unitOfWork = unitOfWork;
            _storeReceiptGoodRepository = storeReceiptGoodRepository;
        }

        public async Task<Guid> Handle(CreateStoreReceiptGoodCommand request, CancellationToken cancellationToken)
        {
            var storeReceiptGood = new StoreReceiptGood(
                                        request.StoreReceiptHeadId,
                                        request.CommodityId,
                                        request.PackageId,
                                        request.BrandName,
                                        request.NoBrandName,
                                        request.PackNB,
                                        request.GrossWeight,
                                        request.NetWeight,
                                        request.Volume,
                                        request.Remark,
                                        request.IsHeavy,
                                        request.IsNonPalletized,
                                        request.IsDamaged,
                                        request.IsVoluminous,
                                        request.IsDangerous,
                                        request.DangerousNotNoticed,
                                        request.DangerousCode,
                                        request.Classification,
                                        request.IgnitionTemperature,
                                        request.IgnitionTemperatureUnit
                                    );

            await _storeReceiptGoodRepository.InsertAsync(storeReceiptGood);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return storeReceiptGood.Id;
        }

    }
}
