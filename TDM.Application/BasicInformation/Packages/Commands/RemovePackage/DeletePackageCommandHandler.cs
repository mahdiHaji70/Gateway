using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Packages.Commands.RemovePackage
{
    public class DeletePackageCommandHandler : IRequestHandler<DeletePackageCommand, bool>
    {
        private readonly IRepository<Package> _packageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePackageCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Package> packageRepository)
        {
            _unitOfWork = unitOfWork;
            _packageRepository = packageRepository;
        }

        public async Task<bool> Handle(DeletePackageCommand request, CancellationToken cancellationToken)
        {
            var package = await _packageRepository.GetAsync(request.Id);

            if (package == null)
                throw new Exception("Package not found");

            _packageRepository.Delete(package);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
