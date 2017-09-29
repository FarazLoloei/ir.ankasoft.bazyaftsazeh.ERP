namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Migrations
{
    using ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories;
    using ir.ankasoft.entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            #region Identity Core
            const string adminName = "FarazLoloei", developerName = "farazloloei@gmail.com";
            const string adminPassword = "Admin?123", developerPassword = "AnkA@Dev96";
            const string adminRoleName = "Admin", developerRoleName = "Developer";
            const string adminEmail = "Admin@bazyaftsazeh.com", developerEmail = "farazloloei@gmail.com";
            // Developer
            if (!context.Roles.Any(r => r.Name == developerRoleName))
            {
                var store = new ApplicationRoleStore(context);
                var manager = new ApplicationRoleManagerRepository(store);
                var role = new ApplicationRole { Name = developerRoleName };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == developerName))
            {
                var store = new UserStore<ApplicationUser, ApplicationRole, long,
                                          ApplicationUserLogin, ApplicationUserRole,
                                          ApplicationUserClaim>(context);
                var manager = new ApplicationUserManagerRepository(store);
                var user = new ApplicationUser { UserName = developerName, Email = developerEmail };

                var result = manager.Create(user, developerPassword);
                result = manager.AddToRole(user.Id, developerRoleName);
            }
            // Admin
            if (!context.Roles.Any(r => r.Name == adminRoleName))
            {
                var store = new ApplicationRoleStore(context);
                var manager = new ApplicationRoleManagerRepository(store);
                var role = new ApplicationRole { Name = adminRoleName };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == adminName))
            {
                var store = new UserStore<ApplicationUser, ApplicationRole, long,
                                          ApplicationUserLogin, ApplicationUserRole,
                                          ApplicationUserClaim>(context);
                var manager = new ApplicationUserManagerRepository(store);
                var user = new ApplicationUser { UserName = adminName, Email = adminEmail };

                var result = manager.Create(user, adminPassword);
                result = manager.AddToRole(user.Id, adminRoleName);
            }
            #endregion

            
        }
    }
}