﻿using ir.ankasoft.infrastructure;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ir.ankasoft.entities
{
    public class Person : DomainEntity<long>, IDateTracking, IUserTracking
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Family { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{Name}, {Family}";
            }
        }

        public long PartyRefRecId { get; set; }

        [ForeignKey(nameof(PartyRefRecId))]
        public Party Party { get; set; }

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
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult(string.Format(Resource._0CanntBeEmpty, nameof(Name)), new[] { nameof(Name) });
            }

            if (string.IsNullOrEmpty(Family))
            {
                yield return new ValidationResult(string.Format(Resource._0CanntBeEmpty, nameof(Family)), new[] { nameof(Family) });
            }
        }

        #endregion Validation
    }
}