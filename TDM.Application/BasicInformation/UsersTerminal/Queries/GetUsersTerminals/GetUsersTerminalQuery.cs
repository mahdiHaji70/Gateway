using MediatR;
using TDM.Application.BasicInformation.UsersTerminal.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.UsersTerminal.Queries.GetUsersTerminal
{
    public record GetUsersTerminalQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<UserTerminalDto>>;

}
