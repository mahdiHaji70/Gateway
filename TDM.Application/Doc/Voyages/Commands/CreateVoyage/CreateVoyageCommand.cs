using MediatR;

namespace TDM.Application.Doc.Voyages.Commands.CreateVoyage
{
    public record CreateVoyageCommand : IRequest<Guid>
    {
        public string VoyageNo { get; init; } = null!;
        public string NoticeNo { get; init; } = null!;
        public DateTime ETA { get; init; }
        public DateTime ETD { get; init; }
        public string ShipLine { get; init; } = null!;
        public string ShipAgent { get; init; } = null!;
        public string VesselName { get; init; } = null!;
        public string Imo { get; init; } = null!;
    }
}
