using ir.ankasoft.entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories
{
    //class ApplicationRoleManagerRepository
    //{
    //}

    public class ApplicationRoleManagerRepository : RoleManager<ApplicationRole, long>
    {
        // PASS CUSTOM APPLICATION ROLE AND INT AS TYPE ARGUMENTS TO CONSTRUCTOR:
        public ApplicationRoleManagerRepository(IRoleStore<ApplicationRole, long> roleStore)
            : base(roleStore)
        {
        }

        // PASS CUSTOM APPLICATION ROLE AS TYPE ARGUMENT:
        public static ApplicationRoleManagerRepository Create(
            IdentityFactoryOptions<ApplicationRoleManagerRepository> options, IOwinContext context)
        {
            return new ApplicationRoleManagerRepository(
                new ApplicationRoleStore(context.Get<ApplicationDbContext>()));
        }
    }
}