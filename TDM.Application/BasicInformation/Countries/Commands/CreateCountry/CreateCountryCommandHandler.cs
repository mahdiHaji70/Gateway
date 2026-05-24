using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Countries.Commands.CreateCountry
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Guid>
    {
        private readonly IRepository<Country> _countryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCountryCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Country> countryRepository)
        {
            _unitOfWork = unitOfWork;
            _countryRepository = countryRepository;
        }

        public async Task<Guid> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var country = new Country(
                request.Name,
                request.Code);

            await _countryRepository.InsertAsync(country);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return country.Id;
        }
    }
}
