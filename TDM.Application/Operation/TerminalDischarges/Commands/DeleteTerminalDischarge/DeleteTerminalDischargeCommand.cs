using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Operation.TerminalDischarges.Commands.DeleteTerminalDischarge
{
   
    public class DeleteTerminalDischargeCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteTerminalDischargeCommand(Guid id)
        {
            Id = id;
        }
    }
}
