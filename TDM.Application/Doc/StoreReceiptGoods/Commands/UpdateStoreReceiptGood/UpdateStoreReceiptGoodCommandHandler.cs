using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.StoreReceiptGoods.Commands.CreateStoreReceiptGood;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.StoreReceiptGoods.Commands.UpdateStoreReceiptGood
{
    public class UpdateStoreReceiptGoodCommandHandler : IRequestHandler<UpdateStoreReceiptGoodCommand, Guid>
    {
        private readonly IRepository<StoreReceiptGood> _storeReceiptGoodRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStoreReceiptGoodCommandHandler(IUnitOfWork unitOfWork
            , IRepository<StoreReceiptGood> storeReceiptGoodRepository)
        {
            _unitOfWork = unitOfWork;
            _storeReceiptGoodRepository = storeReceiptGoodRepository;
        }

        public async Task<Guid> Handle(UpdateStoreReceiptGoodCommand request, CancellationToken cancellationToken)
        {
            var storeReceiptGood = await _storeReceiptGoodRepository.GetAsync(request.Id);

            if (storeReceiptGood == null)
                throw new Exception("storeReceiptGood not found");

            storeReceiptGood.Update(
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

             _storeReceiptGoodRepository.Update(storeReceiptGood);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return storeReceiptGood.Id;
        }

    }
}
