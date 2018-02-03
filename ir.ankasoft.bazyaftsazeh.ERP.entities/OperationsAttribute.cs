using ir.ankasoft.infrastructure;
using ir.ankasoft.resource;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities
{
    public class OperationsAttribute : DomainEntity<long>
    {
        public string Title { get; set; }

        public bool IsRequired { get; set; } = true;

        public Enums.DataType DataType { get; set; } = Enums.DataType.String;

        public long OperationRefRecId { get; set; }

        [ForeignKey(nameof(OperationRefRecId))]
        public DocumentOperation Operation { get; set; }

        #region Validation

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (IsRequired)
                yield return new ValidationResult(
               string.Format(Resource._0CanntBeEmpty, Title), new[] { Title });

            if (OperationRefRecId < 1)
                yield return new ValidationResult(
                    string.Format(Resource._0CanntBeEmpty, nameof(OperationRefRecId)), new[] { nameof(OperationRefRecId) });
        }

        #endregion Validation
    }
}