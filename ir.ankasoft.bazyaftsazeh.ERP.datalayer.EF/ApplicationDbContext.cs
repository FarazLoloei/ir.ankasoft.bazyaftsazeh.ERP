
using ir.ankasoft.entities;
using ir.ankasoft.infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationDbContext()
            //: base("DefaultConnectionString")
            : base("Data Source=.;Initial Catalog=ir.ankasoft.bazyaftsazeh.ERP;Persist Security Info=True;User ID=bazyaftsazeh;Password=@BazyafSazeh!2#;MultipleActiveResultSets=True")
        //: base("Data Source=87.247.179.160,1833;Initial Catalog=ir.anka.Storage;Persist Security Info=True;User ID=Anka;Password=AnkAt@123;MultipleActiveResultSets=True")
        {
            //Configuration.LazyLoadingEnabled = false;
        }

        static ApplicationDbContext()
        {
            //Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<entities.Cost> Costs { get; set; }
        public DbSet<entities.Document> Document { get; set; }
        public DbSet<entities.GovernmentPlan> GovernmentPlan { get; set; }
        public DbSet<entities.Imperfection> Imperfection { get; set; }
        public DbSet<entities.Importer> Importer { get; set; }
        public DbSet<entities.Organization> Organization { get; set; }
        public DbSet<entities.Payment> Payment { get; set; }
        public DbSet<entities.Plan> Plans { get; set; }
        public DbSet<entities.Plate> Plates { get; set; }
        public DbSet<entities.PreDefineTitle> PreDefineTitles { get; set; }
        public DbSet<entities.ReplacementsPlan> ReplacementsPlan { get; set; }
        public DbSet<entities.Vehicle> Vehicles { get; set; }
        public DbSet<entities.VehicleTip> VehicleTips { get; set; }

        public DbSet<City> Cities { get; set; }
        public DbSet<Communication> Communications { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PostalAddress> PostalAddresses { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public DbSet<ContextMenu> ContextMenus { get; set; }
        public DbSet<ContextMenuItem> ContextMenuItems { get; set; }

        public override int SaveChanges()
        {
            // Need to manually delete all "owned objects" that have been removed from their owner, otherwise they'll be orphaned.
            //var orphanedObjects = ChangeTracker.Entries().Where(
            //  e => (e.State == EntityState.Modified || e.State == EntityState.Added) &&
            //    e.Entity is IHasOwner &&
            //      e.Reference("Owner").CurrentValue == null);

            //foreach (var orphanedObject in orphanedObjects)
            //{
            //    orphanedObject.State = EntityState.Deleted;
            //}

            using (var dbContextTransaction = base.Database.BeginTransaction())
            {
                try
                {
                    var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
                    foreach (DbEntityEntry item in modified)
                    {
                        var changedOrAddedItem = item.Entity as IDateTracking;
                        var userChangeOrAddedItem = item.Entity as IUserTracking;
                        if (changedOrAddedItem != null)
                        {
                            string userId = "1";
                            if (System.Web.HttpContext.Current != null)
                            {
                                userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                            }
                            if (item.State == EntityState.Added)
                            {
                                changedOrAddedItem.createdDateTime = DateTime.Now;
                                if (userChangeOrAddedItem != null)
                                    userChangeOrAddedItem.creatorUserRefRecId = Convert.ToInt64(userId);
                            }
                            else if (item.State == EntityState.Modified)
                            {
                                changedOrAddedItem.modifiedDateTime = DateTime.Now;
                                if (userChangeOrAddedItem != null)
                                    userChangeOrAddedItem.modifierUserRefRecId = Convert.ToInt64(userId);
                            }
                        }
                    }

                    ///*Counter Party*/
                    //// Manualy add new party number on every counter party inserted
                    //foreach (var entity in ChangeTracker.Entries<CounterParty>())
                    //{
                    //    if (entity.State == EntityState.Added)
                    //    {
                    //        entity.Property("PartyNumber").CurrentValue =
                    //            (this.CounterParties.Any() ? this.CounterParties.Max(x => x.PartyNumber) : 10000) + 1;
                    //    }
                    //}
                    ///*Purch Order*/
                    //// Manualy add new Request Id on every Purch order inserted
                    //long lastRequestId = 0;
                    //foreach (var entity in ChangeTracker.Entries<PurchOrder>())
                    //{
                    //    if (entity.State == EntityState.Added)
                    //    {
                    //        entity.Property("PurchId").CurrentValue =
                    //            (this.PurchOrders.Any() ? this.PurchOrders.Max(x => x.PurchId) : 10000) + 1;
                    //        lastRequestId = Convert.ToInt64(entity.Property("PurchId").CurrentValue);
                    //        //base.SaveChanges();
                    //    }

                    //}
                    //long lastSalesId = 0;
                    //foreach (var entity in ChangeTracker.Entries<SalesOrder>())
                    //{
                    //    if (entity.State == EntityState.Added)
                    //    {
                    //        entity.Property("SalesId").CurrentValue =
                    //            (this.SalesOrder.Any() ? this.SalesOrder.Max(x => x.SalesId) : 10000) + 1;
                    //        lastSalesId = Convert.ToInt64(entity.Property("SalesId").CurrentValue);
                    //    }
                    //    //base.SaveChanges();
                    //}
                    //long lastTransferId = 0;
                    //foreach (var entity in ChangeTracker.Entries<Transfer>())
                    //{
                    //    if (entity.State == EntityState.Added)
                    //    {
                    //        entity.Property("TransferId").CurrentValue =
                    //            (this.Transfers.Any() ? this.Transfers.Max(x => x.TransferId) : 10000) + 1;
                    //        lastTransferId = Convert.ToInt64(entity.Property("TransferId").CurrentValue);
                    //    }
                    //}

                    ///*Invent Trans*/
                    //// Manualy add Trans DateTime on every InventTrans inserted
                    //long inventTransId = 0;
                    //foreach (var entity in ChangeTracker.Entries<InventTrans>())
                    //{
                    //    if (entity.State == EntityState.Added)
                    //    {
                    //        entity.Property("TransDate").CurrentValue = DateTime.Now;
                    //        if (inventTransId == 0) inventTransId = (this.InventTrans.Any() ? this.InventTrans.Max(x => x.InventTransId) : 10000);
                    //        entity.Property("InventTransId").CurrentValue = inventTransId = inventTransId + 1;
                    //        if (Convert.ToInt64(entity.Property("PurchId").CurrentValue) == 0)
                    //            entity.Property("PurchId").CurrentValue = lastRequestId;
                    //        if (Convert.ToInt64(entity.Property("TransferId").CurrentValue) == 0)
                    //            entity.Property("TransferId").CurrentValue = lastTransferId;
                    //        if (Convert.ToInt64(entity.Property("SalesId").CurrentValue) == 0)
                    //            entity.Property("SalesId").CurrentValue = lastSalesId;
                    //    }
                    //}

                    //foreach (var entity in ChangeTracker.Entries<Invoice>())
                    //{
                    //    if (entity.State == EntityState.Added)
                    //    {
                    //        entity.Property("InvoiceNo").CurrentValue =
                    //            (this.Invoices.Any() ? this.Invoices.Max(x => x.InvoiceNo) : 10000) + 1;
                    //    }
                    //}

                    //var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
                    //foreach (DbEntityEntry item in modified)
                    //{
                    //    var changedOrAddedItem = item.Entity as IDateTracking;
                    //    var userChangeOrAddedItem = item.Entity as IUserTracking;
                    //    if (changedOrAddedItem != null)
                    //    {
                    //        string userId = "1";
                    //        if (System.Web.HttpContext.Current != null)
                    //        {
                    //            userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                    //        }
                    //        if (item.State == EntityState.Added)
                    //        {
                    //            changedOrAddedItem.createdDateTime = DateTime.Now;
                    //            if (userChangeOrAddedItem != null)
                    //                userChangeOrAddedItem.creatorUserRefRecId = Convert.ToInt64(userId);
                    //        }
                    //        else if (item.State == EntityState.Modified)
                    //        {
                    //            changedOrAddedItem.modifiedDateTime = DateTime.Now;
                    //            if (userChangeOrAddedItem != null)
                    //                userChangeOrAddedItem.modifierUserRefRecId = Convert.ToInt64(userId);
                    //        }
                    //    }
                    //}

                    int result;
                    result = base.SaveChanges();
                    dbContextTransaction.Commit();
                    return result;
                }
                catch (DbEntityValidationException entityException)
                {
                    var errors = entityException.EntityValidationErrors;
                    var result = new StringBuilder();
                    var allErrors = new List<ValidationResult>();
                    foreach (var error in errors)
                    {
                        foreach (var validationError in error.ValidationErrors)
                        {
                            result.AppendFormat("{3} Entity of type {0} has validation error \"{1}\" for property {2}.{3}",
                                error.Entry.Entity.GetType().ToString(),
                                validationError.ErrorMessage,
                                validationError.PropertyName,
                                Environment.NewLine);
                            var domainEntity = error.Entry.Entity as DomainEntity<int>;
                            if (domainEntity != null)
                            {
                                result.Append(domainEntity.IsTransient() ?
                                    "  This entity was added in this session.\r\n" :
                                    string.Format("  The Id of the entity is {0}.{1}",
                                        domainEntity.recId,
                                        Environment.NewLine));
                            }
                            allErrors.Add(new ValidationResult(validationError.ErrorMessage, new[] { validationError.PropertyName }));
                        }
                    }
                    dbContextTransaction.Rollback();
                    throw new ModelValidationException(result.ToString(), entityException, allErrors);
                }
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<ApplicationRole>().ToTable("Roles");
            modelBuilder.Entity<ApplicationUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<ApplicationUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<ApplicationUserClaim>().ToTable("UserClaims");

            modelBuilder.Entity<Province>()
                .HasRequired(x => x.creatorUser)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<entities.PreDefineTitle>()
                .HasRequired(x => x.creatorUser)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Party>()
                .HasRequired(x => x.creatorUser)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasRequired(x => x.creatorUser)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<entities.Plan>()
                .HasRequired(x => x.creatorUser)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<entities.Organization>()
                .HasRequired(x => x.creatorUser)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<entities.Importer>()
                .HasRequired(x => x.creatorUser)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<entities.Vehicle>()
                .HasRequired(x => x.creatorUser)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<entities.Plate>()
                .HasRequired(x => x.creatorUser)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<entities.VehicleTip>()
                .HasRequired(x => x.creatorUser)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<entities.Document>()
                .HasRequired(x => x.Investor)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<entities.Document>()
                .HasRequired(x => x.PlateOwner)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<entities.Plan>()
                .HasRequired(x => x.Representor)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<entities.Plan>()
                .HasRequired(x => x.Representor)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<entities.ReplacementsPlan>()
                .HasRequired(x => x.ReplacementsVehicle)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<entities.Organization>()
                .HasRequired(x => x.Party)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<entities.Importer>()
                .HasRequired(x => x.Party)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Party>()
                .HasMany(x => x.CommunicationCollection)
                .WithOptional()
                .HasForeignKey(c => c.PartyRefRecId);

            modelBuilder.Entity<Person>()
               .HasMany(x => x.CommunicationCollection)
               .WithOptional()
               .HasForeignKey(c => c.PersonRefRecId);

            modelBuilder.Entity<entities.Importer>()
               .HasMany(x => x.CommunicationCollection)
               .WithOptional()
               .HasForeignKey(c => c.ImporterRefRecId);

            modelBuilder.Entity<entities.Organization>()
               .HasMany(x => x.CommunicationCollection)
               .WithOptional()
               .HasForeignKey(c => c.OrganizationRefRecId);

            modelBuilder.Entity<ContextMenu>()
                .HasRequired(x => x.creatorUser)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}
