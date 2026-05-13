using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name)
            : base($"{name} was not found.")
        {
        }
    }
}
