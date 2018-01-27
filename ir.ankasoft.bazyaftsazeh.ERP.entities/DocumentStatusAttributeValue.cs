using ir.ankasoft.entities;
using ir.ankasoft.infrastructure;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities
{
    public class OperationsAttributeValue : DomainEntity<long>, IDateTracking, IUserTracking
    {
        public long DocumentStatusRefRecId { get; set; }

        [ForeignKey(nameof(DocumentStatusRefRecId))]
        public DocumentStatus DocumentStatus { get; set; }

        public long OperationsAttributeRefRecId { get; set; }

        [ForeignKey(nameof(OperationsAttributeRefRecId))]
        public OperationsAttribute OperationsAttribute { get; set; }

        public string Value { get; set; }

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
            if (string.IsNullOrEmpty(Value))
                yield return new ValidationResult(
                    string.Format(Resource._0CanntBeEmpty, nameof(Value)), new[] { nameof(Value) });
        }

        #endregion Validation
    }
}