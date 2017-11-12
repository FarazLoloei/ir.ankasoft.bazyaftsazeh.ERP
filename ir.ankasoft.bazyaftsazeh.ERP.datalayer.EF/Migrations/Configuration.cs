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

            #endregion Identity Core



            context.Objectives.AddOrUpdate(_ => _.Title,
                new Objective() { Title = "Party", Type = ankasoft.entities.Enums.ObjectiveType.Controller }, //1
                new Objective() { Title = "Person", Type = ankasoft.entities.Enums.ObjectiveType.Controller }, //2
                new Objective() { Title = "Importer", Type = ankasoft.entities.Enums.ObjectiveType.Controller }, //3
                new Objective() { Title = "Organization", Type = ankasoft.entities.Enums.ObjectiveType.Controller }, //4
                new Objective() { Title = "Cost", Type = ankasoft.entities.Enums.ObjectiveType.Controller }, //5
                new Objective() { Title = "Imperfection", Type = ankasoft.entities.Enums.ObjectiveType.Controller }, //6
                new Objective() { Title = "VehicleTip", Type = ankasoft.entities.Enums.ObjectiveType.Controller } //7
                );
            context.SaveChanges();
            var _objectiveRefRecId = 1;
            context.ContextMenuItems.AddOrUpdate(
            #region Party
                new ContextMenuItem()
                {
                    Title = "New",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = false,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-file-o",
                    GroupCode = 1,
                    Priority = 1
                },
                new ContextMenuItem()
                {
                    Title = "Edit",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-pencil",
                    GroupCode = 1,
                    Priority = 2
                },
                new ContextMenuItem()
                {
                    Title = "Delete",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-trash-o",
                    GroupCode = 1,
                    Priority = 3
                },
                new ContextMenuItem()
                {
                    Title = "ExportToExcel",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = false,
                    ShowOnRow = true,
                    DisableOnRow = true,
                    Icon = "fa-file-excel-o",
                    GroupCode = 2,
                    Priority = 1
                },
                new ContextMenuItem()
                {
                    Title = "EditCommunication",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = false,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-phone",
                    GroupCode = 3,
                    Priority = 1
                },
                new ContextMenuItem()
                {
                    Title = "EditPostalAddress",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = false,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-address-card-o",
                    GroupCode = 3,
                    Priority = 1
                },
                new ContextMenuItem()
                {
                    Title = "DefineAsPerson",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = false,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-user",
                    GroupCode = 4,
                    Priority = 1
                },
                new ContextMenuItem()
                {
                    Title = "DefineAsImporter",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = false,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-male",
                    GroupCode = 4,
                    Priority = 2
                },
                new ContextMenuItem()
                {
                    Title = "DefineAsOrganization",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = false,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-building-o",
                    GroupCode = 4,
                    Priority = 3
                });
            #endregion

            _objectiveRefRecId = 2;
            context.ContextMenuItems.AddOrUpdate(
            #region Person
                new ContextMenuItem()
                {
                    Title = "New",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = true,
                    Icon = "fa-file-o",
                    GroupCode = 1,
                    Priority = 1
                },
                new ContextMenuItem()
                {
                    Title = "Edit",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-pencil",
                    GroupCode = 1,
                    Priority = 2
                },
                new ContextMenuItem()
                {
                    Title = "Delete",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-trash-o",
                    GroupCode = 1,
                    Priority = 3
                },
                new ContextMenuItem()
                {
                    Title = "ExportToExcel",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = false,
                    ShowOnRow = true,
                    DisableOnRow = true,
                    Icon = "fa-file-excel-o",
                    GroupCode = 2,
                    Priority = 1
                },
                new ContextMenuItem()
                {
                    Title = "EditCommunication",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = false,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-phone",
                    GroupCode = 3,
                    Priority = 1
                },
                new ContextMenuItem()
                {
                    Title = "EditPostalAddress",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = false,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-address-card-o",
                    GroupCode = 3,
                    Priority = 1
                });
            #endregion

            _objectiveRefRecId = 3;
            context.ContextMenuItems.AddOrUpdate(
            #region Importer
                new ContextMenuItem()
                {
                    Title = "New",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = true,
                    Icon = "fa-file-o",
                    GroupCode = 1,
                    Priority = 1
                },
                new ContextMenuItem()
                {
                    Title = "Edit",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-pencil",
                    GroupCode = 1,
                    Priority = 2
                },
                new ContextMenuItem()
                {
                    Title = "Delete",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-trash-o",
                    GroupCode = 1,
                    Priority = 3
                },
                new ContextMenuItem()
                {
                    Title = "ExportToExcel",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = false,
                    ShowOnRow = true,
                    DisableOnRow = true,
                    Icon = "fa-file-excel-o",
                    GroupCode = 2,
                    Priority = 1
                },
                new ContextMenuItem()
                {
                    Title = "EditCommunication",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = false,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-phone",
                    GroupCode = 3,
                    Priority = 1
                },
                new ContextMenuItem()
                {
                    Title = "EditPostalAddress",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = false,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-address-card-o",
                    GroupCode = 3,
                    Priority = 1
                });
            #endregion

            _objectiveRefRecId = 4;
            context.ContextMenuItems.AddOrUpdate(
            #region Organization
                new ContextMenuItem()
                {
                    Title = "New",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = true,
                    Icon = "fa-file-o",
                    GroupCode = 1,
                    Priority = 1
                },
                new ContextMenuItem()
                {
                    Title = "Edit",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-pencil",
                    GroupCode = 1,
                    Priority = 2
                },
                new ContextMenuItem()
                {
                    Title = "Delete",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-trash-o",
                    GroupCode = 1,
                    Priority = 3
                },
                new ContextMenuItem()
                {
                    Title = "ExportToExcel",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = false,
                    ShowOnRow = true,
                    DisableOnRow = true,
                    Icon = "fa-file-excel-o",
                    GroupCode = 2,
                    Priority = 1
                },
                new ContextMenuItem()
                {
                    Title = "EditCommunication",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = false,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-phone",
                    GroupCode = 3,
                    Priority = 1
                },
                new ContextMenuItem()
                {
                    Title = "EditPostalAddress",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = false,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-address-card-o",
                    GroupCode = 3,
                    Priority = 1
                });
            #endregion

            _objectiveRefRecId = 5;
            context.ContextMenuItems.AddOrUpdate(
            #region Cost
                new ContextMenuItem()
                {
                    Title = "New",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = false,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-file-o",
                    GroupCode = 1,
                    Priority = 1
                },
                new ContextMenuItem()
                {
                    Title = "Edit",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-pencil",
                    GroupCode = 1,
                    Priority = 2
                },
                new ContextMenuItem()
                {
                    Title = "Delete",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-trash-o",
                    GroupCode = 1,
                    Priority = 3
                },
                new ContextMenuItem()
                {
                    Title = "ExportToExcel",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = false,
                    ShowOnRow = true,
                    DisableOnRow = true,
                    Icon = "fa-file-excel-o",
                    GroupCode = 2,
                    Priority = 1
                });
            #endregion

            _objectiveRefRecId = 6;
            context.ContextMenuItems.AddOrUpdate(
            #region Imperfection
                new ContextMenuItem()
                {
                    Title = "New",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = false,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-file-o",
                    GroupCode = 1,
                    Priority = 1
                },
                new ContextMenuItem()
                {
                    Title = "Edit",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-pencil",
                    GroupCode = 1,
                    Priority = 2
                },
                new ContextMenuItem()
                {
                    Title = "Delete",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-trash-o",
                    GroupCode = 1,
                    Priority = 3
                },
                new ContextMenuItem()
                {
                    Title = "ExportToExcel",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = false,
                    ShowOnRow = true,
                    DisableOnRow = true,
                    Icon = "fa-file-excel-o",
                    GroupCode = 2,
                    Priority = 1
                });
            #endregion

            _objectiveRefRecId = 7;
            context.ContextMenuItems.AddOrUpdate(
            #region VehicleTip
                new ContextMenuItem()
                {
                    Title = "New",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = false,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-file-o",
                    GroupCode = 1,
                    Priority = 1
                },
                new ContextMenuItem()
                {
                    Title = "Edit",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-pencil",
                    GroupCode = 1,
                    Priority = 2
                },
                new ContextMenuItem()
                {
                    Title = "Delete",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = true,
                    ShowOnRow = true,
                    DisableOnRow = false,
                    Icon = "fa-trash-o",
                    GroupCode = 1,
                    Priority = 3
                },
                new ContextMenuItem()
                {
                    Title = "ExportToExcel",
                    ObjectiveRefRecId = _objectiveRefRecId,
                    RoleRefRecId = 1,
                    ShowOnHeader = true,
                    DisableOnHeader = false,
                    ShowOnRow = true,
                    DisableOnRow = true,
                    Icon = "fa-file-excel-o",
                    GroupCode = 2,
                    Priority = 1
                });
            #endregion
        }
    }
}