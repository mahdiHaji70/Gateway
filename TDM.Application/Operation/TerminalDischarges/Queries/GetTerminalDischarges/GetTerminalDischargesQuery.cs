using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Models;
using TDM.Application.Operation.TerminalDischarges.DTOs;

namespace TDM.Application.Operation.TerminalDischarges.Queries.GetGetTerminalDischarges
{
    public record GetTerminalDischargesQuery(
        int PageNumber = 1, int PageSize = 10, string? Search = null,
        DateTime? DateFrom = null, DateTime? DateTo = null,
        Guid? DeclarationItemId = null, Guid? StoreId = null) : IRequest<PagedResult<TerminalDischargeDto>>;
}
