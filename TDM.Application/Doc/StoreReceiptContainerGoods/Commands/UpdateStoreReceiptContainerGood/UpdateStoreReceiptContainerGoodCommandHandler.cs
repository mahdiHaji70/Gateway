using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.StoreReceiptContainerGoods.Commands.UpdateStoreReceiptContainerGood;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.StoreReceiptContainerContainerGoods.Commands.UpdateStoreReceiptContainerContainerGood
{
    public class UpdateStoreReceiptContainerGoodCommandHandler : IRequestHandler<UpdateStoreReceiptContainerGoodCommand, Guid>
    {
        private readonly IRepository<StoreReceiptContainerGood> _storeReceiptContainerGoodRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStoreReceiptContainerGoodCommandHandler(IUnitOfWork unitOfWork
            , IRepository<StoreReceiptContainerGood> storeReceiptContainerGoodRepository)
        {
            _unitOfWork = unitOfWork;
            _storeReceiptContainerGoodRepository = storeReceiptContainerGoodRepository;
        }

        public async Task<Guid> Handle(UpdateStoreReceiptContainerGoodCommand request, CancellationToken cancellationToken)
        {
            var storeReceiptContainerGood = await _storeReceiptContainerGoodRepository.GetAsync(request.Id);

            if (storeReceiptContainerGood == null)
                throw new Exception("storeReceiptContainerGood not found");

            storeReceiptContainerGood.Update(
                                        request.StoreReceiptContainerId,
                                        request.CommodityId,
                                        request.PackageId,
                                        request.BrandName,
                                        request.NoBrandName,
                                        request.PackNB,
                                        request.GrossWeight,
                                        request.NetWeight,
                                        request.Volume,
                                        request.IsHeavy,
                                        request.IsNonPalletized,
                                        request.IsDamaged,
                                        request.IsVoluminous,
                                        request.IsDangerous,
                                        request.DangerousNotNoticed
                                      
                                    );

            _storeReceiptContainerGoodRepository.Update(storeReceiptContainerGood);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return storeReceiptContainerGood.Id;
        }

    }
}
