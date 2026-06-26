using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Operation.WeightBridges.Commands.UpdateWeightBridge
{
    public class UpdateWeightBridgeCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid DeclarationId { get; set; }
        public Guid GateId { get; set; }
        public string Vehicle { get; set; }
        public Decimal? GrossWeight { get; set; }
        public Decimal? TareWeight { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
