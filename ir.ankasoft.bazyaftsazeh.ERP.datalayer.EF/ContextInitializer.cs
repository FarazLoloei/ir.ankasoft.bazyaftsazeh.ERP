using System.Data.Entity;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF
{
    /// <summary>
    /// Used to initialize the StorageContextInitializer.
    /// </summary>
    public static class ContextInitializer
    {
        /// <summary>
        /// Sets the IDatabaseInitializer for the application.
        /// </summary>
        /// <param name="dropDatabaseIfModelChanges">When true, uses the DropCreateDatabaseIfModelChanges to recreate the database when necessary.
        /// Otherwise, database initialization is disabled by passing null to the SetInitializer method.
        /// </param>
        public static void Init(bool dropDatabaseIfModelChanges)
        {
            if (dropDatabaseIfModelChanges)
            {
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges());//(new DropCreateDatabaseIfModelChanges());
                using (var db = new ApplicationDbContext())
                {
                    db.Database.Initialize(false);
                }
            }
            else
            {
                Database.SetInitializer<ApplicationDbContext>(null);
            }
        }
    }
}