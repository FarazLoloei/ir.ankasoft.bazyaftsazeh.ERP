using System.Web;

namespace ir.ankasoft.infrastructure.DataContext
{
    /// <summary>
    /// A helper class to create application platform specific store containers.
    /// </summary>
    /// <typeparam name="T">The type for which to create the container.</typeparam>
    public static class DataContextFactory<T> where T : class
    {
        private static IDataContextContainer<T> _DataContextContainer;

        /// <summary>
        /// Creates a new container that uses HttpContext.Current.Items (when HttpContext.Current is not null) or Thread.Items.
        /// </summary>
        /// <returns>A contact store container to store objects. </returns>
        public static IDataContextContainer<T> CreateContainer()
        {
            if (_DataContextContainer == null)
            {
                if (HttpContext.Current == null)
                {
                    _DataContextContainer = new ThreadDataContextContainer<T>();
                }
                else
                {
                    _DataContextContainer = new HttpDataContextContainer<T>();
                }
            }
            return _DataContextContainer;
        }
    }
}