using ir.ankasoft.infrastructure.DataContext;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF
{
    /// <summary>
    /// Manages instances of the ContactManagerContext and stores them in an appropriate storage container.
    /// </summary>
    public static class DataContextFactory
    {
        /// <summary>
        /// Clears out the current ContactManagerContext.
        /// </summary>
        public static void Clear()
        {
            var dataContextContainer = DataContextFactory<ApplicationDbContext>.CreateContainer();
            dataContextContainer.Clear();
        }

        /// <summary>
        /// Retrieves an instance of ContactManagerContext from the appropriate storage container or
        /// creates a new instance and stores that in a container.
        /// </summary>
        /// <returns>An instance of ContactManagerContext.</returns>
        //public static StorageContext GetDataContext()
        //{
        //    var dataContextStorageContainer = DataContextStorageFactory<StorageContext>.CreateStorageContainer();
        //    var contactManagerContext = dataContextStorageContainer.GetDataContext();
        //    if (contactManagerContext == null)
        //    {
        //        contactManagerContext = new StorageContext();
        //        dataContextStorageContainer.Store(contactManagerContext);
        //    }
        //    return contactManagerContext;
        //}

        public static ApplicationDbContext GetDataContext()
        {
            var dataContextContainer = DataContextFactory<ApplicationDbContext>.CreateContainer();
            var contactManagerContext = dataContextContainer.GetDataContext();
            if (contactManagerContext == null)
            {
                contactManagerContext = new ApplicationDbContext();
                dataContextContainer.Store(contactManagerContext);
            }
            return contactManagerContext;
        }
    }
}