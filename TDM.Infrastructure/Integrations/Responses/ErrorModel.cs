using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Infrastructure.Integrations.Responses
{
    public class ErrorModel
    {
        public required string PropertyName { get; set; }
        public required string ErrorMessage { get; set; }
    }
}
