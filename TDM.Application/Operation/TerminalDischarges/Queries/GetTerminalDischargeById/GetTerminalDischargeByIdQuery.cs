using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Operation.TerminalDischarges.DTOs;


namespace TDM.Application.Operation.TerminalDischarges.Queries.GetTerminalDischargeById
{
    public record GetTerminalDischargeByIdQuery(Guid Id) : IRequest<TerminalDischargeDto>;
}
