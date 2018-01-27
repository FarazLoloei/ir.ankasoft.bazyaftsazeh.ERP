using ir.ankasoft.infrastructure;
using ir.ankasoft.resource;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities
{
    public class DocumentStatusHelper1 : DomainEntity<long>
    {
        //public long DocumentStatusRefRecId { get; set; }

        //[ForeignKey(nameof(DocumentStatusRefRecId))]
        //public DocumentStatus DocumentStatus { get; set; }

        public long OperationRefRecId { get; set; }

        [ForeignKey(nameof(OperationRefRecId))]
        public DocumentOperation Operation { get; set; }

        public virtual ICollection<OperationsAttributeValue> AttributeValuesCollection { get; set; }

        #region Validation

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (OperationRefRecId < 1)
                yield return new ValidationResult(
                    string.Format(Resource._0CanntBeEmpty,
                                  nameof(OperationRefRecId)),
                    new[] { nameof(OperationRefRecId) });
        }

        #endregion Validation
    }
}