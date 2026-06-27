using MediatR;
using TDM.Application.Operation.Gates.DTOs;


namespace TDM.Application.Operation.Gates.Queries.GetGateById
{
   
    public record GetGateByIdQuery(Guid Id) : IRequest<GateDto>;
}
