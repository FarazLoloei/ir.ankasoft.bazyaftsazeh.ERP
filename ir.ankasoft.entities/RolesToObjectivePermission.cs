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
    public class RolesToObjectivePermission : DomainEntity<long>, IDateTracking, IUserTracking
    {
        public long RoleRefRecId { get; set; }

        [ForeignKey(nameof(RoleRefRecId))]
        public ApplicationUserRole Role { get; set; }

        public long ObjectiveRefRecId { get; set; }

        [ForeignKey(nameof(ObjectiveRefRecId))]
        public Objective Objective { get; set; }

        public string ValidStatusIdCollectionCommaSeperate { get; set; }

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
            if (RoleRefRecId < 1)
            {
                yield return new ValidationResult(string.Format(Resource._0CanntBeEmpty, nameof(RoleRefRecId)), new[] { nameof(RoleRefRecId) });
            }

            if (ObjectiveRefRecId < 1)
            {
                yield return new ValidationResult(string.Format(Resource._0CanntBeEmpty, nameof(ObjectiveRefRecId)), new[] { nameof(ObjectiveRefRecId) });
            }
        }

        #endregion Validation
    }
}
