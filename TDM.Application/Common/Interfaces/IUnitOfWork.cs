using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
