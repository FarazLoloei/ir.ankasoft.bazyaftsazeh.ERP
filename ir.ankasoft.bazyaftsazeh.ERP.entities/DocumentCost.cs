using ir.ankasoft.entities;
using ir.ankasoft.infrastructure;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities
{
    public class DocumentCost : DomainEntity<long>, IDateTracking, IUserTracking
    {
        public long PreDefineTitleRefRecId { get; set; }

        [ForeignKey(nameof(PreDefineTitleRefRecId))]
        public PreDefineTitle Title { get; set; }

        public double Value { get; set; }

        public long DocumentRefRecId { get; set; }

        [ForeignKey(nameof(DocumentRefRecId))]
        public Document Document { get; set; }

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
            if (Value < 0)
            {
                yield return new ValidationResult(string.Format(Resource._0MustBeGreaterThan1, 0, nameof(Value)), new[] { nameof(Value) });
            }
        }

        #endregion Validation
    }
}