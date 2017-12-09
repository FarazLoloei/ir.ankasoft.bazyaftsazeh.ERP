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
    public class GovernmentPlan : DomainEntity<long>, IDateTracking, IUserTracking
    {
        public long OrganizationRefRecId { get; set; }

        [ForeignKey(nameof(OrganizationRefRecId))]
        public Organization Organization { get; set; }

        public string PermissionNumber { get; set; }

        //public PlanType Type { get; set; }

        public long RepresentorRefRecId { get; set; }

        [ForeignKey(nameof(RepresentorRefRecId))]
        public Person Representor { get; set; }

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
            if (RepresentorRefRecId == 0)
            {
                yield return new ValidationResult(string.Format(Resource._0CanntBeEmpty, nameof(RepresentorRefRecId)), new[] { nameof(RepresentorRefRecId) });
            }
        }

        #endregion Validation
    }
}