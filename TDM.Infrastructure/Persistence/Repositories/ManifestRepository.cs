using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class ManifestRepository : Repository<Manifest>, IManifestRepository
    {
        public ManifestRepository(TDMDbContext context) : base(context)
        {
        }

        public async Task<bool> ExistsByNoticeNo(string noticeNo)
        {
            return await _dbSet.AnyAsync(x => x.NoticeNo == noticeNo);
        }
    }
}
