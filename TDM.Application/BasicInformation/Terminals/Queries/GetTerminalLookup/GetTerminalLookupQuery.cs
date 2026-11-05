using MediatR;
using TDM.Application.BasicInformation.Terminals.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Terminals.Queries.GetTerminalLookup
{
    public record GetTerminalLookupQuery(string? Search = null, int PageNumber = 1, int PageSize = 20)
        : IRequest<PagedResult<TerminalDto>>;
}
