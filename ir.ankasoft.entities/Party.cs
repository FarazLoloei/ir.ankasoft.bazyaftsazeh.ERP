using ir.ankasoft.infrastructure;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ir.ankasoft.entities
{
    public class Party : DomainEntity<long>, IDateTracking, IUserTracking
    {
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(10)]
        public string NationalCode { get; set; }

        public Enums.PersonalTitle PersonalTitle { get; set; }

        public string Description { get; set; }

        public virtual ICollection<PostalAddress> PostalAddressCollection { get; set; }

        public virtual ICollection<Communication> CommunicationCollection { get; set; }


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

            if (string.IsNullOrEmpty(NationalCode))
            {
                yield return new ValidationResult(string.Format(Resource._0CanntBeEmpty, nameof(NationalCode)), new[] { nameof(NationalCode) });
            }
        }

        #endregion Validation
    }
}