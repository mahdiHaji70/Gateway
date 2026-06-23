using MediatR;
using TDM.Application.BasicInformation.UsersTerminal.DTOs;

namespace TDM.Application.BasicInformation.UsersTerminal.Queries.GetUserTerminalByNationalId
{
    public record GetUserTerminalByNationalIdQuery(string NationalId) : IRequest<UserTerminalDto>;

}
