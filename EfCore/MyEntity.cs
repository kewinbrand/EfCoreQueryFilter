using System;

namespace WebApplication.EfCore
{
    public class MyEntity
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
    }
}