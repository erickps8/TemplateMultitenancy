using Microsoft.AspNetCore.Http;
using SaasKit.Multitenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.Business.Interfaces;
using Template.Business.Models.MultiTenancy;

namespace Template.Business.Servicecs.MultiTenancy
{
    public class TenantService : ITenantService
    {
        public Task<bool> Adicionar(Tenant tenant)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Atualizar(Tenant tenant)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
