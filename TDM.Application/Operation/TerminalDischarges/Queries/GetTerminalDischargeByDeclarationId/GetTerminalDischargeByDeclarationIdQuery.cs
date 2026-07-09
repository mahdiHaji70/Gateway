using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Models;
using TDM.Application.Operation.TerminalDischarges.DTOs;

namespace TDM.Application.Operation.TerminalDischarges.Queries.GetTerminalDischargeByIpasDeclarationNo
{
      public record GetTerminalDischargeByDeclarationIdQuery(Guid declarationId, int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<TerminalDischargeDto>>;

}
