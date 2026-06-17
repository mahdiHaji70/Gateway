using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.CargoTypes.Commands.UpdateCargoType
{
    public class UpdateCargoTypeCommandHandler : IRequestHandler<UpdateCargoTypeCommand, Guid>
    {

        private readonly IRepository<CargoType> _cargoTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCargoTypeCommandHandler(IUnitOfWork unitOfWork
            , IRepository<CargoType> cargoTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _cargoTypeRepository = cargoTypeRepository;
        }

        public async Task<Guid> Handle(UpdateCargoTypeCommand request, CancellationToken cancellationToken)
        {
            var cargoType = await _cargoTypeRepository.GetAsync(request.Id);

            if (cargoType == null)
                throw new Exception("cargotype not found");

            cargoType.Update(request.Name);

            _cargoTypeRepository.Update(cargoType);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return cargoType.Id;
        }
    }
}
