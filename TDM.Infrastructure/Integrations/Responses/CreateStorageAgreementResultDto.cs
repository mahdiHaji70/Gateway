using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Infrastructure.Integrations.Responses
{
    public class CreateStorageAgreementResultDto
    {
        public Guid Id { get; set; }
        public string No { get; set; } = default!;
    }
}
