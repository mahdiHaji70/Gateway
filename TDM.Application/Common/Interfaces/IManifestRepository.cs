using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IManifestRepository : IRepository<Manifest>
    {
        Task<bool> ExistsByNoticeNo(string noticeNo);
    }
}
