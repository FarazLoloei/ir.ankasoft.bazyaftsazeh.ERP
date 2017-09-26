using System.ComponentModel.DataAnnotations.Schema;

namespace ir.ankasoft.entities
{
    public interface IUserTracking
    {
        /// <summary>
        /// Gets or sets the UserId that create the object.
        /// </summary>
        long creatorUserRefRecId { get; set; }

        [ForeignKey(nameof(creatorUserRefRecId))]
        ApplicationUser creatorUser { get; set; }

        /// <summary>
        /// Gets or sets the UserId that modify the object.
        /// </summary>
        long? modifierUserRefRecId { get; set; }

        [ForeignKey(nameof(modifierUserRefRecId))]
        ApplicationUser modifierUser { get; set; }
    }
}