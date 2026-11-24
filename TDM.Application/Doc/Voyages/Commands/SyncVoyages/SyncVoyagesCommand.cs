using TDM.Application.Doc.Voyages.DTOs;
using MediatR;

namespace TDM.Application.Doc.Voyages.Commands.SyncVoyages
{
    public record SyncVoyagesCommand : IRequest<SyncVoyagesResultDto>;
}
