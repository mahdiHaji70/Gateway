using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Countries.Commands.UpdateCountry
{
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, Guid>
    {
        private readonly IRepository<Country> _countryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCountryCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Country> countryRepository)
        {
            _unitOfWork = unitOfWork;
            _countryRepository = countryRepository;
        }

        public async Task<Guid> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var country = await _countryRepository.GetAsync(request.Id);

            if (country == null)
                throw new Exception("Country not found");

            country.Update(request.Name, request.Code);

            _countryRepository.Update(country);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return country.Id;
        }
    }
}
