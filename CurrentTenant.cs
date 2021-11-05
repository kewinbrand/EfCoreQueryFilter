using System;

namespace WebApplication
{
    public class CurrentTenant
    {
        public Guid TenantId { get; set; }

        public CurrentTenant()
        {
            TenantId = Guid.NewGuid();
        }
    }
}