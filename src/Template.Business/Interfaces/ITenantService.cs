using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Business.Models.MultiTenancy;

namespace Template.Business.Interfaces
{
    public interface ITenantService : IDisposable
    {
        Task<bool> Adicionar(Tenant tenant);
        Task<bool> Atualizar(Tenant tenant);
        Task<bool> Remover(Guid id);        
        Task<int> SaveChanges();
    }
}
