using ir.ankasoft.infrastructure;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ir.ankasoft.entities
{
    public class Notification : DomainEntity<long>, IDateTracking, IUserTracking
    {
        public Notification()
        {
        }

        [Required]
        [MaxLength(100)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(100)]
        public string Summery { get; set; }

        public string Body { get; set; }
        public DateTime PublishDate { get; set; }

        [NotMapped]
        public string PublishDateShamsi
        {
            get
            {
                return tools.Convert.gregorianDateTimeToFragmentedPersianDateTime(PublishDate).ToShortDateString();
            }
            set
            {
                PublishDate = tools.Convert.persianDateToGregorianDate(value);
            }
        }

        [NotMapped]
        public string PublishDateAge
        {
            get
            {
                return tools.Anka.Age.Format(PublishDate);
            }
        }

        //public long NotificationTypeRefRecId { get; set; }

        //[ForeignKey(nameof(NotificationTypeRefRecId))]
        //public NotificationType Type { get; set; }

        public Enums.NotificationType Type { get; set; }

        public DateTime createdDateTime { get; set; }
        public DateTime? modifiedDateTime { get; set; }
        public long creatorUserRefRecId { get; set; }

        [ForeignKey(nameof(creatorUserRefRecId))]
        public ApplicationUser creatorUser { get; set; }

        public long? modifierUserRefRecId { get; set; }

        [ForeignKey(nameof(modifierUserRefRecId))]
        public ApplicationUser modifierUser { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Subject))
                yield return new ValidationResult(
                    string.Format(Resource._0CanntBeEmpty,
                                  nameof(Subject)),
                    new[] { nameof(Subject) });
        }
    }
}