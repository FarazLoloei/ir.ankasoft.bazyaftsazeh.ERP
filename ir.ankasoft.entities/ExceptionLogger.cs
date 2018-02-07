using ir.ankasoft.infrastructure;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ir.ankasoft.entities
{
    public class ExceptionLogger : DomainEntity<long>, IDateTracking, IUserTracking
    {
        [Required]
        [MaxLength(150)]
        public string Controller { get; set; }

        [Required]
        [MaxLength(150)]
        public string Action { get; set; }

        public int StepCode { get; set; } = 0;

        [Required]
        public string ExceptionMessage { get; set; }

        public string Paremeters { get; set; }

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
            if (string.IsNullOrEmpty(Controller))
                yield return new ValidationResult(
                    string.Format(Resource._0CanntBeEmpty,
                                  nameof(Controller)),
                    new[] { nameof(Controller) });

            if (string.IsNullOrEmpty(Action))
                yield return new ValidationResult(
                    string.Format(Resource._0CanntBeEmpty,
                                  nameof(Action)),
                    new[] { nameof(Action) });
        }

        #endregion Validation
    }
}