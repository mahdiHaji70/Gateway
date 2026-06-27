using MediatR;

using TDM.Application.Common.Models;
using TDM.Application.Operation.Gates.DTOs;

namespace TDM.Application.Operation.Gates.Queries.GetGates
{
    public record GetGatesQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<GateDto>>;
}
