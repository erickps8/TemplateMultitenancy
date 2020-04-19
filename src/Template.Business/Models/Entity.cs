using System;
using Template.Business.Models.MultiTenancy;

namespace Template.Business.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        //TenantRelationship
        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
    }
}
