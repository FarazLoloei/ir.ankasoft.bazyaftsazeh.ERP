using ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF;
using System.Data.Entity;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC
{
    public class IdentityConfig
    {
    }

    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            //InitializeIdentityForEF(context);
            base.Seed(context);
        }

        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role
        //public static void InitializeIdentityForEF(ApplicationDbContext db)
        //{
        //    var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManagerRepository>();
        //    var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManagerRepository>();
        //    const string adminName = "alamdari", developerName = "Anka";
        //    const string adminPassword = "admin?123", developerPassword = "AnkA@Dev95";
        //    const string adminRoleName = "Admin", developerRoleName = "Developer";

        //    //Create Role Admin if it does not exist
        //    var adminRole = roleManager.FindByName(adminRoleName);
        //    if (adminRole == null)
        //    {
        //        adminRole = new ApplicationRole(adminRoleName);
        //        var roleresult = roleManager.Create(adminRole);
        //    }

        //    var adminUser = userManager.FindByName(adminName);
        //    if (adminUser == null)
        //    {
        //        adminUser = new ApplicationUser { UserName = adminName, Email = adminName };
        //        var result = userManager.Create(adminUser, adminPassword);
        //        result = userManager.SetLockoutEnabled(adminUser.Id, false);
        //    }

        //    // Add user admin to Role Admin if not already added
        //    var adminRolesForUser = userManager.GetRoles(adminUser.Id);
        //    if (!adminRolesForUser.Contains(adminRole.Name))
        //    {
        //        var result = userManager.AddToRole(adminUser.Id, adminRole.Name);
        //    }

        //    //Create Role Developer if it does not exist
        //    var developerRole = roleManager.FindByName(developerRoleName);
        //    if (developerRole == null)
        //    {
        //        developerRole = new ApplicationRole(developerRoleName);
        //        var roleresult = roleManager.Create(developerRole);
        //    }

        //    var developerUser = userManager.FindByName(developerName);
        //    if (developerUser == null)
        //    {
        //        developerUser = new ApplicationUser { UserName = developerName, Email = developerName };
        //        var result = userManager.Create(developerUser, developerPassword);
        //        result = userManager.SetLockoutEnabled(developerUser.Id, false);
        //    }

        //    // Add user admin to Role Admin if not already added
        //    var developerRolesForUser = userManager.GetRoles(developerUser.Id);
        //    if (!developerRolesForUser.Contains(developerRole.Name))
        //    {
        //        var result = userManager.AddToRole(developerUser.Id, developerRole.Name);
        //    }
        //}
    }
}