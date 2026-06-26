using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Application.Operation.Gates.Commands.CreateGate
{
    public class CreateGateCommand: IRequest<Guid>
    {
        public Guid DeclarationId { get; set; }
        public Declaration Declaration { get; set; }
        public string Vehicle { get; set; }
        public Guid? ContainerId { get; set; }
        public DateTime? EnterDate { get; set; }
        public DateTime? ExitDate { get; set; }
    }
}
