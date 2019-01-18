﻿using System;

namespace LinFx.Domain.Models.MultiTenancy
{
    public class TenantIdWrapper
    {
        /// <summary>
        /// Null indicates the host.
        /// Not null value for a tenant.
        /// </summary>
        public Guid? TenantId { get; }

        public TenantIdWrapper(Guid? tenantId)
        {
            TenantId = tenantId;
        }
    }
}
