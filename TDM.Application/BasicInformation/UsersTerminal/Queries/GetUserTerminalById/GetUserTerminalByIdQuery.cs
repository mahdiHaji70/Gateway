using MediatR;
using TDM.Application.BasicInformation.UsersTerminal.DTOs;

namespace TDM.Application.BasicInformation.UsersTerminal.Queries.GetUserTerminalById
{
    public record GetUserTerminalByIdQuery(Guid Id) : IRequest<UserTerminalDto>;

}
