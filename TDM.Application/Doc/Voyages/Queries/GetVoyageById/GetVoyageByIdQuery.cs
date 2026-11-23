using MediatR;
using TDM.Application.Doc.Voyages.DTOs;

namespace TDM.Application.Doc.Voyages.Queries.GetVoyageById
{
    public record GetVoyageByIdQuery(Guid Id) : IRequest<VoyageDto>;

}
