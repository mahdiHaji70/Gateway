using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Application.Operation.WeightBridges.DTOs
{
    public class WeightBridgeDto
    {
        public Guid DeclarationId { get; set; }
        public string DeclarationNumber { get; set; }
        public Guid GateId { get; set; }
        public string Vehicle { get; set; }
        public Decimal? GrossWeight { get; set; }
        public Decimal? TareWeight { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
