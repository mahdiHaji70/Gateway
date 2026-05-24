using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Countries.Commands.RemoveCountry
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, bool>
    {
        private readonly IRepository<Country> _countryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCountryCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Country> countryRepository)
        {
            _unitOfWork = unitOfWork;
            _countryRepository = countryRepository;
        }

        public async Task<bool> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var country = await _countryRepository.GetAsync(request.Id);

            if (country == null)
                throw new Exception("Country not found");

            _countryRepository.Delete(country);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
