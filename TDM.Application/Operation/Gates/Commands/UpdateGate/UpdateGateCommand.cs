using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Application.Operation.Gates.Commands.UpdateGate
{
    public class UpdateGateCommand:IRequest <Guid>
    {
        public Guid Id { get; set; }
        public Guid DeclarationId { get; set; }
        public string Vehicle { get; set; }
        public Guid? ContainerId { get; set; }
        public DateTime? EnterDate { get; set; }
        public DateTime? ExitDate { get; set; }
    }
}
