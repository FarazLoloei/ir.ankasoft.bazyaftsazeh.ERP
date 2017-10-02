using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ir.ankasoft.infrastructure.DataContextstore
{
    /// <summary>
    /// A helper class to create application platform specific store containers.
    /// </summary>
    /// <typeparam name="T">The type for which to create the container.</typeparam>
    public static class DataContextstoreFactory<T> where T : class
    {
        private static IDataContextstoreContainer<T> _dataContextstoreContainer;

        /// <summary>
        /// Creates a new container that uses HttpContext.Current.Items (when HttpContext.Current is not null) or Thread.Items.
        /// </summary>
        /// <returns>A contact store container to store objects. </returns>
        public static IDataContextstoreContainer<T> CreatestoreContainer()
        {
            if (_dataContextstoreContainer == null)
            {
                if (HttpContext.Current == null)
                {
                    _dataContextstoreContainer = new ThreadDataContextstoreContainer<T>();
                }
                else
                {
                    _dataContextstoreContainer = new HttpDataContextstoreContainer<T>();
                }
            }
            return _dataContextstoreContainer;
        }
    }
}
