using ir.ankasoft.entities;
using ir.ankasoft.infrastructure;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities
{
    public class DocumentStatus : DomainEntity<long>, IDateTracking, IUserTracking
    {
        public long DocumentRefRecId { get; set; }

        [ForeignKey(nameof(DocumentRefRecId))]
        public Document Document { get; set; }

        public string Description { get; set; }

        public DateTime TransactionDateTime { get; set; } = DateTime.Now;

        public long DocumentOperationRefRecId { get; set; }

        [ForeignKey(nameof(DocumentOperationRefRecId))]
        public DocumentOperation Operation { get; set; }

        public virtual ICollection<OperationsAttributeValue> AttributeValuesCollection { get; set; }

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
            if (DocumentRefRecId < 1)
                yield return new ValidationResult(
                    string.Format(Resource._0CanntBeEmpty,
                                  nameof(DocumentRefRecId)),
                    new[] { nameof(DocumentRefRecId) });
        }

        #endregion Validation
    }
}