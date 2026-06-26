using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Operation.Gates.Commands.DeleteGate
{
     public class DeleteGateCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteGateCommand(Guid id)
        {
            Id = id;
        }
    }
}
