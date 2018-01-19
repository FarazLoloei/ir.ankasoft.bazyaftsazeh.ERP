using ir.ankasoft.infrastructure;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities
{
    public class FormRepo : DomainEntity<long>
    {
        [MaxLength(200)]
        public string FormURL { get; set; }

        #region Validation

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return null;
            //if (OperationRefRecId < 1)
            //    yield return new ValidationResult(
            //        string.Format(Resource._0CanntBeEmpty,
            //                      nameof(OperationRefRecId)),
            //        new[] { nameof(OperationRefRecId) });

            //if (FormRepoRefRecId < 1)
            //    yield return new ValidationResult(
            //        string.Format(Resource._0CanntBeEmpty,
            //                      nameof(FormRepoRefRecId)),
            //        new[] { nameof(FormRepoRefRecId) });
        }

        #endregion Validation
    }
}