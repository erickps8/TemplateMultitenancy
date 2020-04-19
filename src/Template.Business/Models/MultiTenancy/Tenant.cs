using System;

namespace Template.Business.Models.MultiTenancy
{
    public class Tenant : EntityTenant
    {
        public string Name { get; set; }
        public string UrlComplete { get; set; }
        public string HostName { get; set; }
    }
}
