using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Packages.Commands.UpdatePackage
{
    public class UpdatePackageCommandHandler : IRequestHandler<UpdatePackageCommand, Guid>
    {
        private readonly IRepository<Package> _packageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePackageCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Package> packageRepository)
        {
            _unitOfWork = unitOfWork;
            _packageRepository = packageRepository;
        }

        public async Task<Guid> Handle(UpdatePackageCommand request, CancellationToken cancellationToken)
        {
            var package = await _packageRepository.GetAsync(request.Id);

            if (package == null)
                throw new Exception("Package not found");

            package.Update(request.Name, request.Code);

            _packageRepository.Update(package);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return package.Id;
        }
    }
}
