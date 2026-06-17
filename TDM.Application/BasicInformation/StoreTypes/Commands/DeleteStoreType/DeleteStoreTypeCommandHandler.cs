using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.CargoTypes.Commands.DeleteCargoType;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.StoreTypes.Commands.DeleteStoreType
{
   
    public class DeleteStoreTypeCommandHandler : IRequestHandler<DeleteStoreTypeCommand, bool>
    {
        private readonly IRepository<StoreType> _storeTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStoreTypeCommandHandler(IUnitOfWork unitOfWork
            , IRepository<StoreType> storeTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _storeTypeRepository = storeTypeRepository;
        }

        public async Task<bool> Handle(DeleteStoreTypeCommand request, CancellationToken cancellationToken)
        {
            var storeType = await _storeTypeRepository.GetAsync(request.Id);

            if (storeType == null)
                throw new Exception("storetype not found");

            _storeTypeRepository.Delete(storeType);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
