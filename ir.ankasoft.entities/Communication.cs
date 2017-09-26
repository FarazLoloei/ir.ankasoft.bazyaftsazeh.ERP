﻿using ir.ankasoft.infrastructure;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir.ankasoft.entities
{
    public class Communication : DomainEntity<long>, IDateTracking, IUserTracking
    {
        public Communication()
        {
            IsPrimary = false;
        }

        public Enums.CommunicationType CommunicationType { get; set; }
        public bool IsPrimary { get; set; }

        [Required]
        public string Value { get; set; }

        public string Description { get; set; }

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
