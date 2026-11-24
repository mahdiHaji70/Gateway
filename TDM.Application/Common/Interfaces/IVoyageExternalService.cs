using TDM.Application.Doc.Voyages.DTOs;

namespace TDM.Application.Common.Interfaces
{
    public interface IVoyageExternalService
    {
        Task<List<VoyageSyncDto>> GetVoyagesFromDate(DateTime lastDate, CancellationToken cancellationToken = default);
    }
}
