using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.Voyages.Commands.CreateVoyage
{
    public class CreateVoyageCommandHandler : IRequestHandler<CreateVoyageCommand, Guid>
    {
        private readonly IRepository<Voyage> _voyageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateVoyageCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Voyage> voyageRepository)
        {
            _unitOfWork = unitOfWork;
            _voyageRepository = voyageRepository;
        }

        public async Task<Guid> Handle(CreateVoyageCommand request, CancellationToken cancellationToken)
        {
            var voyage = new Voyage(
                request.VoyageNo,
                request.NoticeNo,
                request.ETA,
                request.ETD,
                request.ShipLine,
                request.ShipAgent,
                request.VesselName,
                request.Imo);

            await _voyageRepository.InsertAsync(voyage);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return voyage.Id;
        }
    }
}
