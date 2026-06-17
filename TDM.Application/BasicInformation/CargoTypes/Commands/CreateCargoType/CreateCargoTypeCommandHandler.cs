using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Cities.Commands.CreateCity;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.CargoTypes.Commands.CreateCargoType
{

    public class CreateCargoTypeCommandHandler : IRequestHandler<CreateCargoTypeCommand, Guid>
    {
        private readonly IRepository<CargoType> _cargoTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCargoTypeCommandHandler(IUnitOfWork unitOfWork
            , IRepository<CargoType> cargoTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _cargoTypeRepository = cargoTypeRepository;
        }

        public async Task<Guid> Handle(CreateCargoTypeCommand request, CancellationToken cancellationToken)
        {
            var cargoType = new CargoType(request.Name);

            await _cargoTypeRepository.InsertAsync(cargoType);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return cargoType.Id;
        }

    }
}
