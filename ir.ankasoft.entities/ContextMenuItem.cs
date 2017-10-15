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
    public class ContextMenuItem : DomainEntity<long>, IDateTracking, IUserTracking
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public long ParentRefRecId { get; set; }

        [ForeignKey(nameof(ParentRefRecId))]
        public ContextMenu Parent { get; set; }

        public long RoleRefRecId { get; set; }

        [ForeignKey(nameof(RoleRefRecId))]
        public ApplicationRole Role { get; set; }

        public bool ShowOnHeader { get; set; } = true;

        public bool DisableOnHeader { get; set; } = false;

        public bool ShowOnRow { get; set; } = true;

        public bool DisableOnRow { get; set; } = false;

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
            if (string.IsNullOrEmpty(Title))
            {
                yield return new ValidationResult(string.Format(Resource._0CanntBeEmpty, nameof(Title)), new[] { nameof(Title) });
            }
        }

        #endregion Validation
    }
}
