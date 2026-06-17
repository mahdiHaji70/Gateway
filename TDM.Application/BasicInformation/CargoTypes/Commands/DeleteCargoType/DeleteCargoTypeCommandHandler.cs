using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Cities.Commands.RemoveCity;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.CargoTypes.Commands.DeleteCargoType
{
    public class DeleteCargoTypeCommandHandler : IRequestHandler<DeleteCargoTypeCommand, bool>
    {
        private readonly IRepository<CargoType> _cargoTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCargoTypeCommandHandler(IUnitOfWork unitOfWork
            , IRepository<CargoType> cargoTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _cargoTypeRepository = cargoTypeRepository;
        }

        public async Task<bool> Handle(DeleteCargoTypeCommand request, CancellationToken cancellationToken)
        {
            var cargoType = await _cargoTypeRepository.GetAsync(request.Id);

            if (cargoType == null)
                throw new Exception("cargotype not found");

            _cargoTypeRepository.Delete(cargoType);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
