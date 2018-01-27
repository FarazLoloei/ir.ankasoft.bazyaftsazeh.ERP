using ir.ankasoft.entities;
using ir.ankasoft.infrastructure;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities
{
    public class DocumentPreRequirement : DomainEntity<long>, IDateTracking, IUserTracking
    {
        public long DocumentRefRecId { get; set; }
        [ForeignKey(nameof(DocumentRefRecId))]
        public Document Document { get; set; }
        public bool HasBargSabz { get; set; }
        public bool HasSanad { get; set; }
        public bool HasAdameKhalafi { get; set; }
        public string Description { get; set; }

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

            if (HasBargSabz && HasSanad && HasAdameKhalafi)
            {
                yield return new ValidationResult(string.Format(Resource.RequiredFiled, 0, nameof(Description)), new[] { nameof(Description) });
            }
        }

        #endregion Validation
    }
}