using System;
using System.Collections.Generic;
using System.Text;
using Template.Business.Models.MultiTenancy;

namespace Template.Business.Interfaces
{
    public interface ITenantRepository : IGenericTenantRepository<Tenant>
    {
    }
}
