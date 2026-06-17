using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Packages.Commands.CreatePackage
{
    public class CreatePackageCommandHandler : IRequestHandler<CreatePackageCommand, Guid>
    {
        private readonly IRepository<Package> _packageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePackageCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Package> packageRepository)
        {
            _unitOfWork = unitOfWork;
            _packageRepository = packageRepository;
        }

        public async Task<Guid> Handle(CreatePackageCommand request, CancellationToken cancellationToken)
        {
            var package = new Package(
                request.Name,
                request.Code);

            await _packageRepository.InsertAsync(package);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return package.Id;
        }
    }
}
