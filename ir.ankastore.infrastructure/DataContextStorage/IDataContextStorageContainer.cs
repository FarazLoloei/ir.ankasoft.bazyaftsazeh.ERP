﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir.ankasoft.infrastructure.DataContextstore
{
    public interface IDataContextstoreContainer<T>
    {
        /// <summary>
        /// Returns an object from the container when it exists. Returns null otherwise.
        /// </summary>
        /// <returns>The object from the container when it exists, null otherwise.</returns>
        T GetDataContext();

        /// <summary>
        /// Stores the object in HttpContext.Current.Items.
        /// </summary>
        /// <param name="objectContext">The object to store.</param>
        void Store(T objectContext);

        /// <summary>
        /// Clears the object from the container.
        /// </summary>
        void Clear();
    }
}
