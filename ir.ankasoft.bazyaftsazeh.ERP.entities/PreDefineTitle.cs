using ir.ankasoft.entities;
using ir.ankasoft.infrastructure;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities
{
    public class PreDefineTitle : DomainEntity<long>, IDateTracking, IUserTracking
    {
        public Enums.TitleType Type { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public double SuggestedPrice { get; set; }

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
            if (string.IsNullOrEmpty(Title))
            {
                yield return new ValidationResult(string.Format(Resource._0CanntBeEmpty, nameof(Title)), new[] { nameof(Title) });
            }

            if (SuggestedPrice < 0)
            {
                yield return new ValidationResult(string.Format(Resource._0MustBeGreaterThan1, 0, nameof(SuggestedPrice)), new[] { nameof(SuggestedPrice) });
            }
        }

        #endregion Validation
    }
}