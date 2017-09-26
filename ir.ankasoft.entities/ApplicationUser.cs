using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ir.ankasoft.entities
{
    //public class ApplicationUser : IdentityUser
    //{
    //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    //    {
    //        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    //        // Add custom user claims here
    //        return userIdentity;
    //    }
    //}

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<long, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>, IUser<long>
    {
        public async Task<ClaimsIdentity>
            GenerateUserIdentityAsync(UserManager<ApplicationUser, long> manager)
        {
            var userIdentity = await manager
                .CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        //public string Address { get; set; }
        //public string City { get; set; }
        //public string State { get; set; }

        //// Use a sensible display name for views:
        //[Display(Name = "Postal Code")]
        //public string PostalCode { get; set; }

        //// Concatenate the address info for display in tables and such:
        //public string DisplayAddress
        //{
        //    get
        //    {
        //        string dspAddress =
        //            string.IsNullOrWhiteSpace(this.Address) ? "" : this.Address;
        //        string dspCity =
        //            string.IsNullOrWhiteSpace(this.City) ? "" : this.City;
        //        string dspState =
        //            string.IsNullOrWhiteSpace(this.State) ? "" : this.State;
        //        string dspPostalCode =
        //            string.IsNullOrWhiteSpace(this.PostalCode) ? "" : this.PostalCode;

        //        return string
        //            .Format("{0} {1} {2} {3}", dspAddress, dspCity, dspState, dspPostalCode);
        //    }
        //}
    }
}