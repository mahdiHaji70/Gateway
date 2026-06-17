using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Stores.Commands.DeleteStore;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Stores.Commands.DeleteStore
{
    public class DeleteStoreCommandHandler : IRequestHandler<DeleteStoreCommand, bool>
    {
        private readonly IRepository<Store> _storeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStoreCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Store> storeRepository)
        {
            _unitOfWork = unitOfWork;
            _storeRepository = storeRepository;
        }

        public async Task<bool> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {
            var Store = await _storeRepository.GetAsync(request.Id);

            if (Store == null)
                throw new Exception("Store not found");

            _storeRepository.Delete(Store);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
