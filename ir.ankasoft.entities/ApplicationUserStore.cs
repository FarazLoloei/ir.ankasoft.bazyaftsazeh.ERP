using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace ir.ankasoft.entities
{
    // Identity framework defines the notion of User and Role stores for accessing user and role information.
    public class ApplicationUserStore :
            UserStore<ApplicationUser, ApplicationRole, long,
            ApplicationUserLogin, ApplicationUserRole,
            ApplicationUserClaim>, IUserStore<ApplicationUser, long>,
            IDisposable
    {
        public ApplicationUserStore() : this(new IdentityDbContext())
        {
            base.DisposeContext = true;
        }

        public ApplicationUserStore(DbContext context)
            : base(context)
        {
        }
    }
}