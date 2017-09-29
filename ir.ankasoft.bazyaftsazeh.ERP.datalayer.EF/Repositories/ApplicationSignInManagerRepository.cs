using ir.ankasoft.entities;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories
{
    //public class ApplicationSignInManagerRepository
    //{
    //}

    public class ApplicationSignInManagerRepository : SignInManager<ApplicationUser, long>
    {
        public ApplicationSignInManagerRepository(ApplicationUserManagerRepository userManager, IAuthenticationManager authenticationManager) :
            base(userManager, authenticationManager)
        { }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManagerRepository)UserManager);
        }

        public static ApplicationSignInManagerRepository Create(IdentityFactoryOptions<ApplicationSignInManagerRepository> options, IOwinContext context)
        {
            return new ApplicationSignInManagerRepository(context.GetUserManager<ApplicationUserManagerRepository>(), context.Authentication);
        }
    }
}