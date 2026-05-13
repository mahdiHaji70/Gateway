using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Common.Models
{
    public class PagedResult<T>
    {
        public IReadOnlyList<T> Items { get; set; } = new List<T>();

        public int TotalCount { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}
