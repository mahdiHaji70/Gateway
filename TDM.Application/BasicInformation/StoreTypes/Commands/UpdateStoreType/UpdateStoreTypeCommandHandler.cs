using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.CargoTypes.Commands.UpdateCargoType;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.StoreTypes.Commands.UpdateStoreType
{
  
    public class UpdateStoreTypeCommandHandler : IRequestHandler<UpdateStoreTypeCommand, Guid>
    {

        private readonly IRepository<StoreType> _storeTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStoreTypeCommandHandler(IUnitOfWork unitOfWork
            , IRepository<StoreType> storeTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _storeTypeRepository = storeTypeRepository;
        }

        public async Task<Guid> Handle(UpdateStoreTypeCommand request, CancellationToken cancellationToken)
        {
            var storeType = await _storeTypeRepository.GetAsync(request.Id);

            if (storeType == null)
                throw new Exception("storeotype not found");

            storeType.Update(request.Name);

            _storeTypeRepository.Update(storeType);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return storeType.Id;
        }
    }

}
