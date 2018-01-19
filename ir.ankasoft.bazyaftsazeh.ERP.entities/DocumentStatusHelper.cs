using ir.ankasoft.infrastructure;
using ir.ankasoft.resource;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities
{
    public class DocumentStatusHelper : DomainEntity<long>
    {
        public long OperationRefRecId { get; set; }

        [ForeignKey(nameof(OperationRefRecId))]
        public DocumentOperation Operation { get; set; }

        public long? FormRepoRefRecId { get; set; }

        [ForeignKey(nameof(FormRepoRefRecId))]
        public FormRepo Form { get; set; }

        #region Validation

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (OperationRefRecId < 1)
                yield return new ValidationResult(
                    string.Format(Resource._0CanntBeEmpty,
                                  nameof(OperationRefRecId)),
                    new[] { nameof(OperationRefRecId) });

            if (FormRepoRefRecId < 1)
                yield return new ValidationResult(
                    string.Format(Resource._0CanntBeEmpty,
                                  nameof(FormRepoRefRecId)),
                    new[] { nameof(FormRepoRefRecId) });
        }

        #endregion Validation
    }
}