using ir.ankasoft.infrastructure;
using ir.ankasoft.resource;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities
{
    //مراحل روند کارتابلی
    public class DocumentOperation : DomainEntity<long>
    {
        [MaxLength(200)]
        public string Title { get; set; }

        public virtual ICollection<OperationsAttribute> AttributeCollection { get; set; }

        #region Validation

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Title))
                yield return new ValidationResult(
                    string.Format(Resource._0CanntBeEmpty,
                                  nameof(Title)),
                    new[] { nameof(Title) });
        }

        #endregion Validation
    }
}