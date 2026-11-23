using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.Voyages.Commands.RemoveVoyage
{
    public class DeleteVoyageCommandHandler : IRequestHandler<DeleteVoyageCommand, bool>
    {
        private readonly IRepository<Voyage> _voyageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteVoyageCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Voyage> voyageRepository)
        {
            _unitOfWork = unitOfWork;
            _voyageRepository = voyageRepository;
        }

        public async Task<bool> Handle(DeleteVoyageCommand request, CancellationToken cancellationToken)
        {
            var voyage = await _voyageRepository.GetAsync(request.Id);

            if (voyage == null)
                throw new Exception("Voyage not found");

            _voyageRepository.Delete(voyage);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
