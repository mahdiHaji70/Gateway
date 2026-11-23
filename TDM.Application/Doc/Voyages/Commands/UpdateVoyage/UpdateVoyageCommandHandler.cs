using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.Voyages.Commands.UpdateVoyage
{
    public class UpdateVoyageCommandHandler : IRequestHandler<UpdateVoyageCommand, Guid>
    {
        private readonly IRepository<Voyage> _voyageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateVoyageCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Voyage> voyageRepository)
        {
            _unitOfWork = unitOfWork;
            _voyageRepository = voyageRepository;
        }

        public async Task<Guid> Handle(UpdateVoyageCommand request, CancellationToken cancellationToken)
        {
            var voyage = await _voyageRepository.GetAsync(request.Id);

            if (voyage == null)
                throw new Exception("Voyage not found");

            voyage.Update(
                request.VoyageNo,
                request.NoticeNo,
                request.ETA,
                request.ETD,
                request.ShipLine,
                request.ShipAgent,
                request.VesselName,
                request.Imo);

            _voyageRepository.Update(voyage);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return voyage.Id;
        }
    }
}
