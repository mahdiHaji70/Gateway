using MediatR;
using TDM.Application.BasicInformation.Terminals.DTOs;

namespace TDM.Application.BasicInformation.Terminals.Queries.GetTerminalById
{
    public record GetTerminalByIdQuery(Guid Id) : IRequest<TerminalDto>;

}
