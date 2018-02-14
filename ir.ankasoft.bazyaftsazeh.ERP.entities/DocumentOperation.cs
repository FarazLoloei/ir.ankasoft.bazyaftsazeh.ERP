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

        public bool HasSubOperation { get; set; } = false;

        public bool CouldAttachAnyFiles { get; set; } = false;

        public int MaxNumberOfImagesForAttach { get; set; } = 4;

        public int MaxNumberOfVideosForAttach { get; set; } = 1;

        [MaxLength(200)]
        public string RelatedFormURL { get; set; }

        [MaxLength(50)]
        public string RolesList { get; set; } = "1";

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