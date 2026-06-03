using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Infrastructure.Integrations.Responses
{
    public class GeneralResponse<T>
    {

        public ResponseStatuses Status { get; set; }
        public string? Message { get; set; }
        public List<ErrorModel>? Errors { get; set; }
        public T? Data { get; set; }
    }
}
