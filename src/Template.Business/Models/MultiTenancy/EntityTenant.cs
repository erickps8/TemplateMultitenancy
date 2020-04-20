using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Business.Models.MultiTenancy
{
    public abstract class EntityTenant
    {
        protected EntityTenant()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
