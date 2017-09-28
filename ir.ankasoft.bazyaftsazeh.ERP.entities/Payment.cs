using ir.ankasoft.entities;
using ir.ankasoft.infrastructure;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities
{
    public class Payment : DomainEntity<long>, IDateTracking, IUserTracking
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [NotMapped]
        public string TransactionDateShamsi
        {
            get
            {
                if (TransactionDate == new DateTime(1753, 1, 1) || TransactionDate == DateTime.MinValue) return string.Empty;
                return tools.Convert.gregorianDateTimeToFragmentedPersianDateTime(TransactionDate).ToShortDateString();
            }
            set
            {
                TransactionDate = tools.Convert.persianDateToGregorianDate(value);
            }
        }

        [Required]
        public DateTime DueDate { get; set; }

        [NotMapped]
        public string DueDateShamsi
        {
            get
            {
                if (DueDate == new DateTime(1753, 1, 1) || DueDate == DateTime.MinValue) return string.Empty;
                return tools.Convert.gregorianDateTimeToFragmentedPersianDateTime(DueDate).ToShortDateString();
            }
            set
            {
                DueDate = tools.Convert.persianDateToGregorianDate(value);
            }
        }

        public Enums.PaymentType PaymentType { get; set; }

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
            if (Price < 0)
            {
                yield return new ValidationResult(string.Format(Resource._0CanntBeEmpty, nameof(Price)), new[] { nameof(Price) });
            }

            if (TransactionDate == null)
            {
                yield return new ValidationResult(string.Format(Resource._0CanntBeEmpty, nameof(TransactionDate)), new[] { nameof(TransactionDate) });
            }

            if (DueDate == null)
            {
                yield return new ValidationResult(string.Format(Resource._0CanntBeEmpty, nameof(DueDate)), new[] { nameof(DueDate) });
            }
        }

        #endregion Validation
    }
}