using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Stores.Commands.CreateStore;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Stores.Commands.CreateStore
{
   
    public class CreateStoreCommandHandler : IRequestHandler<CreateStoreCommand, Guid>
    {
        private readonly IRepository<Store> _storeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateStoreCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Store> storeRepository)
        {
            _unitOfWork = unitOfWork;
            _storeRepository = storeRepository;
        }

        public async Task<Guid> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            var store = new Store(request.Name,request.StoreTypeId);

            await _storeRepository.InsertAsync(store);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return store.Id;
        }

    }
}
