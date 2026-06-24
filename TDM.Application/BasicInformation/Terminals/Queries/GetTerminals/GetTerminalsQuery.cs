using MediatR;
using TDM.Application.BasicInformation.Terminals.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Terminals.Queries.GetTerminals
{
    public record GetTerminalsQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<TerminalDto>>;

}
