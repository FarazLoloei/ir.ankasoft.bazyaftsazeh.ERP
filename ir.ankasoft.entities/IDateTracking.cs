using System;

namespace ir.ankasoft.entities
{
    public interface IDateTracking
    {
        /// <summary>
        /// Gets or sets the date and time the object was created.
        /// </summary>
        DateTime createdDateTime { get; set; }

        /// <summary>
        /// Gets or sets the date and time the object was last modified.
        /// </summary>
        DateTime? modifiedDateTime { get; set; }
    }
}