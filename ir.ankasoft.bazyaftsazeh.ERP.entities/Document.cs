using ir.ankasoft.bazyaftsazeh.ERP.entities.Enums;
using ir.ankasoft.entities;
using ir.ankasoft.infrastructure;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities
{
    public class Document : DomainEntity<long>, IDateTracking, IUserTracking
    {
        public long LastOwnerRefRecId { get; set; }

        [ForeignKey(nameof(LastOwnerRefRecId))]
        public Party LastOwner { get; set; }

        public long PlateOwnerRefRecId { get; set; }

        [ForeignKey(nameof(PlateOwnerRefRecId))]
        public Party PlateOwner { get; set; }

        public long InvestorRefRecId { get; set; }

        [ForeignKey(nameof(InvestorRefRecId))]
        public Party Investor { get; set; }

        public long VehicleRefRecId { get; set; }

        [ForeignKey(nameof(VehicleRefRecId))]
        public Vehicle Vehicle { get; set; }

        public Enums.DocumentPaymentType PaymentType { get; set; }

        public DateTime PaymentDate { get; set; }

        [NotMapped]
        public string PaymentDateShamsi
        {
            get
            {
                if (PaymentDate == new DateTime(1753, 1, 1) || PaymentDate == DateTime.MinValue) return string.Empty;
                return tools.Convert.gregorianDateTimeToFragmentedPersianDateTime(PaymentDate).ToShortDateString();
            }
            set
            {
                PaymentDate = tools.Convert.persianDateToGregorianDate(value);
            }
        }

        public long ContractorRefRecId { get; set; }

        [ForeignKey(nameof(ContractorRefRecId))]
        /// <summary>
        /// پیمانکار
        /// </summary>
        public Party Contractor { get; set; }

        public virtual ICollection<DocumentCost> Costs { get; set; }

        public virtual ICollection<DocumentImperfection> Imperfections { get; set; }

        public virtual PlanType PlanType { get; set; }

        public long? ReplacementRefRecId { get; set; }

        [ForeignKey(nameof(ReplacementRefRecId))]
        public ReplacementPlan ReplacementPlan { get; set; }

        public long? GovernmentPlanRefRecId { get; set; }

        [ForeignKey(nameof(GovernmentPlanRefRecId))]
        public GovernmentPlan GovernmentPlan { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }

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
            if (LastOwnerRefRecId < 0)
                yield return new ValidationResult(string.Format(Resource._0MustBeSelect, 0, nameof(LastOwnerRefRecId)), new[] { nameof(LastOwnerRefRecId) });

            if (PlateOwnerRefRecId < 0)
                yield return new ValidationResult(string.Format(Resource._0MustBeSelect, 0, nameof(PlateOwnerRefRecId)), new[] { nameof(PlateOwnerRefRecId) });

            if (InvestorRefRecId < 0)
                yield return new ValidationResult(string.Format(Resource._0MustBeSelect, 0, nameof(InvestorRefRecId)), new[] { nameof(InvestorRefRecId) });

            if (VehicleRefRecId < 0)
                yield return new ValidationResult(string.Format(Resource._0MustBeSelect, 0, nameof(VehicleRefRecId)), new[] { nameof(VehicleRefRecId) });

            if (ContractorRefRecId < 0)
                yield return new ValidationResult(string.Format(Resource._0MustBeSelect, 0, nameof(ContractorRefRecId)), new[] { nameof(ContractorRefRecId) });

            //if (PlanRefRecId < 0)
            //    yield return new ValidationResult(string.Format(Resource._0MustBeSelect, 0, nameof(PlanRefRecId)), new[] { nameof(PlanRefRecId) });
        }

        #endregion Validation
    }
}