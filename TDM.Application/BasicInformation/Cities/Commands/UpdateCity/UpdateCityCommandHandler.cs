using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Cities.Commands.UpdateCity
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, Guid>
    {
        private readonly IRepository<City> _cityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCityCommandHandler(IUnitOfWork unitOfWork
            , IRepository<City> cityRepository)
        {
            _unitOfWork = unitOfWork;
            _cityRepository = cityRepository;
        }

        public async Task<Guid> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _cityRepository.GetAsync(request.Id);

            if (city == null)
                throw new Exception("City not found");

            city.Update(request.Name, request.Code, request.CountryId);

            _cityRepository.Update(city);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return city.Id;
        }
    }
}
