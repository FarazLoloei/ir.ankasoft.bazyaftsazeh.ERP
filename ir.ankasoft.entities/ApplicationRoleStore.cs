using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace ir.ankasoft.entities
{
    // Identity framework defines the notion of User and Role stores for accessing user and role information.
    public class ApplicationRoleStore
        : RoleStore<ApplicationRole, long, ApplicationUserRole>,
        IQueryableRoleStore<ApplicationRole, long>,
        IRoleStore<ApplicationRole, long>, IDisposable
    {
        public ApplicationRoleStore()
            : base(new IdentityDbContext())
        {
            base.DisposeContext = true;
        }

        public ApplicationRoleStore(DbContext context)
            : base(context)
        {
        }
    }
}