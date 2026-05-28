using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Cities.Commands.CreateCity
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, Guid>
    {
        private readonly IRepository<City> _cityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCityCommandHandler(IUnitOfWork unitOfWork
            , IRepository<City> cityRepository)
        {
            _unitOfWork = unitOfWork;
            _cityRepository = cityRepository;
        }

        public async Task<Guid> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var city = new City(
                request.Name,
                request.Code,
                request.CountryId);

            await _cityRepository.InsertAsync(city);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return city.Id;
        }
    }
}
