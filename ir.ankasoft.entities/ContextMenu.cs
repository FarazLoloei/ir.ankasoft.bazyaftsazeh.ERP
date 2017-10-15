using ir.ankasoft.infrastructure;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir.ankasoft.entities
{
    public class ContextMenu : DomainEntity<long>, IDateTracking, IUserTracking
    {
        [Required]
        [MaxLength(100)]
        public string Controller { get; set; }

        public virtual ICollection<ContextMenuItem> ItemCollection { get; set; }

        #region IDateTracking

        public DateTime createdDateTime { get; set; }

        public DateTime? modifiedDateTime { get; set; }

        #endregion IDateTracking

        #region IUserTracking

        public long creatorUserRefRecId { get; set; }

        [ForeignKey(nameof(creatorUserRefRecId))]
        public ApplicationUser creatorUser { get; set; }

        public long? modifierUserRefRecId { get; set; }

        [ForeignKey(nameof(modifierUserRefRecId))]
        public ApplicationUser modifierUser { get; set; }

        #endregion IUserTracking

        #region Validation

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Controller))
            {
                yield return new ValidationResult(string.Format(Resource._0CanntBeEmpty, nameof(Controller)), new[] { nameof(Controller) });
            }
        }

        #endregion Validation
    }
}
