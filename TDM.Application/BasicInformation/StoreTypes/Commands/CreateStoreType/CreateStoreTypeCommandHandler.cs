using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.StoreTypes.Commands.CreateStoreType;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.StoreTypes.Commands.CreateStoreType
{
    public class CreateStoreTypeCommandHandler : IRequestHandler<CreateStoreTypeCommand, Guid>
    {
        private readonly IRepository<StoreType> _storeTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateStoreTypeCommandHandler(IUnitOfWork unitOfWork
            , IRepository<StoreType> storeTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _storeTypeRepository = storeTypeRepository;
        }

        public async Task<Guid> Handle(CreateStoreTypeCommand request, CancellationToken cancellationToken)
        {
            var storeType = new StoreType(request.Name);

            await _storeTypeRepository.InsertAsync(storeType);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return storeType.Id;
        }
    }
}
