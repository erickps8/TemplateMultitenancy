using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Template.Business.Models.MultiTenancy;
using Template.Business.Interfaces;
using Template.Data.Context;
using Microsoft.AspNetCore.Http;
using SaasKit.Multitenancy;
using System.Linq;

namespace Template.Data.Repository
{
    public class TenantRepository : GenericTenantRepository<Tenant>, ITenantRepository, ITenantResolver<Tenant>
    {
        public TenantRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
        public async Task<TenantContext<Tenant>> ResolveAsync(HttpContext context)
        {
            TenantContext<Tenant> tenantContext = null;

            var teste = context.Request.Path.Value.ToLower();

            var lstEmpresa = teste.Split("/");
            if (lstEmpresa[1] != "swagger")
            {

            
            var tenant = await Db.Tenants.AsNoTracking().FirstOrDefaultAsync(t =>
                t.HostName.Equals(lstEmpresa[2]));

            if (tenant != null)
            {
                tenantContext = new TenantContext<Tenant>(tenant);
            }

            }
            return tenantContext;
        }

        public string[] UrlsTenancy()
        {
            var tenant = Db.Tenants.Select(t => t.UrlComplete).ToArray();
                       
            return tenant;
        }

    }
}
