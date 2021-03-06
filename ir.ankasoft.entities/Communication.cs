﻿using ir.ankasoft.infrastructure;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ir.ankasoft.entities
{
    public class Communication : DomainEntity<long>, IDateTracking, IUserTracking
    {
        public Enums.CommunicationType CommunicationType { get; set; }
        public bool IsPrimary { get; set; } = false;

        [Required]
        public string Value { get; set; }

        public string Description { get; set; }

        public virtual long? PartyRefRecId { get; set; }
        public virtual long? PersonRefRecId { get; set; }
        public virtual long? ImporterRefRecId { get; set; }
        public virtual long? OrganizationRefRecId { get; set; }

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
            if (string.IsNullOrEmpty(Value))
                yield return new ValidationResult(
                    string.Format(Resource._0CanntBeEmpty,
                                  nameof(Value)),
                    new[] { nameof(Value) });
        }

        #endregion Validation
    }
}