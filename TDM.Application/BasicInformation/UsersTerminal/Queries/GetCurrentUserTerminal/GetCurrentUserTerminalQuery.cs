using MediatR;
using TDM.Application.BasicInformation.UsersTerminal.DTOs;

namespace TDM.Application.BasicInformation.UsersTerminal.Queries.GetCurrentUserTerminal
{
    public record GetCurrentUserTerminalQuery() : IRequest<UserTerminalDto>;

}
