using Microsoft.AspNetCore.Identity;
using System;

namespace Template.Identity.Data
{
    public class CustomIdentity : IdentityUser
    {
        public string Nome { get; set; }
        public Guid TenantId { get; set; }
    }
}
