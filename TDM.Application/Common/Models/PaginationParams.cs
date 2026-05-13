using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Common.Models
{
    public class PaginationParams
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}
