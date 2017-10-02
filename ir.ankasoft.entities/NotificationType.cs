using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ir.ankasoft.entities
{
    public class NotificationType : DomainEntity<long>, IDateTracking
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public DateTime createdDateTime { get; set; }
        public DateTime? modifiedDateTime { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Title))
            {
                yield return new ValidationResult("Title Can not be empty", new[] { "Title" });
            }
        }
    }
}