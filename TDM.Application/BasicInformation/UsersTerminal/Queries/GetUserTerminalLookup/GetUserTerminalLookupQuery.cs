using MediatR;
using TDM.Application.BasicInformation.UsersTerminal.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.UsersTerminal.Queries.GetUserTerminalLookup
{
    public record GetUserTerminalLookupQuery(string? Search = null, int PageNumber = 1, int PageSize = 20)
        : IRequest<PagedResult<UserTerminalDto>>;
}
