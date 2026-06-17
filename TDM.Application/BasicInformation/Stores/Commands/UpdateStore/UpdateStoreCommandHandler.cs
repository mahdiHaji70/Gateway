using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Stores.Commands.UpdateStore;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Stores.Commands.UpdateStore
{
    public class UpdateStoreCommandHandler : IRequestHandler<UpdateStoreCommand, Guid>
    {

        private readonly IRepository<Store> _storeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStoreCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Store> storeRepository)
        {
            _unitOfWork = unitOfWork;
            _storeRepository = storeRepository;
        }

        public async Task<Guid> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            var Store = await _storeRepository.GetAsync(request.Id);

            if (Store == null)
                throw new Exception("Store not found");

            Store.Update(request.Name,request.StoreTypeId);

            _storeRepository.Update(Store);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Store.Id;
        }
    }

}
