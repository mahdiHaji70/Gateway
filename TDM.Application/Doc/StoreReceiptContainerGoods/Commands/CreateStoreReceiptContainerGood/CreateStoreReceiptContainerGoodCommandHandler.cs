using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.StoreReceiptContainerGoods.Commands.CreateStoreReceiptContainerGood;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.StoreReceiptContainerContainerGoods.Commands.CreateStoreReceiptContainerContainerGood
{
   
    public class CreateStoreReceiptContainerGoodCommandHandler : IRequestHandler<CreateStoreReceiptContainerGoodCommand, Guid>
    {
        private readonly IRepository<StoreReceiptContainerGood> _storeReceiptContainerGoodRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateStoreReceiptContainerGoodCommandHandler(IUnitOfWork unitOfWork
            , IRepository<StoreReceiptContainerGood> storeReceiptContainerGoodRepository)
        {
            _unitOfWork = unitOfWork;
            _storeReceiptContainerGoodRepository = storeReceiptContainerGoodRepository;
        }

        public async Task<Guid> Handle(CreateStoreReceiptContainerGoodCommand request, CancellationToken cancellationToken)
        {
            var storeReceiptContainerGood = new StoreReceiptContainerGood(
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

            await _storeReceiptContainerGoodRepository.InsertAsync(storeReceiptContainerGood);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return storeReceiptContainerGood.Id;
        }

    }
}
