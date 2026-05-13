using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }

        public DateTime CreatedAt { get; protected set; }
        public Guid CreatedByUserId { get; protected set; }

        public DateTime? UpdatedAt { get; protected set; }
        public Guid? UpdatedByUserId { get; protected set; }

        public void SetCreatedAudit()
        {
            CreatedAt = DateTime.UtcNow;
            //CreatedByUserId = userId;
        }

        public void SetUpdatedAudit()
        {
            UpdatedAt = DateTime.UtcNow;
            //UpdatedByUserId = userId;
        }
    }
}
