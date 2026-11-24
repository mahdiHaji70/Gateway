using TDM.Application.Doc.Voyages.DTOs;
using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.Voyages.Commands.SyncVoyages
{
    public class SyncVoyagesCommandHandler : IRequestHandler<SyncVoyagesCommand, SyncVoyagesResultDto>
    {
        private readonly IVoyageRepository _repository;
        private readonly IVoyageExternalService _externalService;
        private readonly IUnitOfWork _unitOfWork;

        public SyncVoyagesCommandHandler(IVoyageRepository repository,
            IVoyageExternalService externalService, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _externalService = externalService;
            _unitOfWork = unitOfWork;
        }

        public async Task<SyncVoyagesResultDto> Handle(SyncVoyagesCommand request, CancellationToken cancellationToken)
        {
            var lastDate = await _repository.GetLastNoticeDateAsync(cancellationToken);
            var voyages = await _externalService.GetVoyagesFromDate(lastDate, cancellationToken);

            var result = new SyncVoyagesResultDto { FromDate = lastDate, LastDate = lastDate };
            if (voyages.Count == 0)
                return result;

            var existing = await _repository.GetByIpasIdsAsync(voyages.Select(x => x.IpasVoyageId), cancellationToken);
            var byId = existing.ToDictionary(x => x.IpasVoyageId!.Value);
            foreach (var item in voyages.OrderBy(x => x.NoticeDate))
            {
                if (item.IpasVoyageId == Guid.Empty || item.NoticeDate == default)
                    throw new Exception("Voyage ID and notice date are required for synchronization.");
                if (!item.ETA.HasValue || !item.ETD.HasValue)
                    throw new Exception($"ETA and ETD are required for voyage '{item.VoyageNo}'.");

                if (byId.TryGetValue(item.IpasVoyageId, out var voyage))
                {
                    voyage.Update(item.VoyageNo, item.NoticeNo, item.ETA.Value, item.ETD.Value,
                        item.ShipLine, item.ShipAgent, item.VesselName, item.Imo);
                    result.UpdatedCount++;
                }
                else
                {
                    voyage = new Voyage(item.VoyageNo, item.NoticeNo, item.ETA.Value, item.ETD.Value,
                        item.ShipLine, item.ShipAgent, item.VesselName, item.Imo);
                    await _repository.InsertAsync(voyage);
                    byId.Add(item.IpasVoyageId, voyage);
                    result.InsertedCount++;
                }

                voyage.SetIpasVoyage(item.IpasVoyageId, item.NoticeDate);
                if (item.NoticeDate > result.LastDate)
                    result.LastDate = item.NoticeDate;
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
