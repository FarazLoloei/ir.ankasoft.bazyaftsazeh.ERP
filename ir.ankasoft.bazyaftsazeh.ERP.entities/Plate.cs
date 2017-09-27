﻿using ir.ankasoft.entities;
using ir.ankasoft.infrastructure;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities
{
    public class Plate : DomainEntity<long>, IDateTracking, IUserTracking
    {
        [Required]
        [MaxLength(20)]
        public string Number { get; set; }

        public Enums.PlateSeries Series { get; set; }

        [Required]
        [MaxLength(100)]
        public string Color { get; set; }

        [MaxLength(100)]
        public string Shape { get; set; }

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
            if (string.IsNullOrEmpty(Number))
            {
                yield return new ValidationResult(string.Format(Resource._0CanntBeEmpty, nameof(Number)), new[] { nameof(Number) });
            }
            if (string.IsNullOrEmpty(Color))
            {
                yield return new ValidationResult(string.Format(Resource._0CanntBeEmpty, nameof(Color)), new[] { nameof(Color) });
            }
        }

        #endregion Validation
    }
}