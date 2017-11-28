﻿using ir.ankasoft.entities;
using ir.ankasoft.infrastructure;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Resources;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities
{
    public class VehicleTip : DomainEntity<long>, IDateTracking, IUserTracking
    {
        [Required]
        [MaxLength(100)]
        public string System { get; set; }

        public Enums.VehicleType Type { get; set; } = Enums.VehicleType.MotorCar;

        [Required]
        public long Capasity { get; set; }

        public Enums.CapasityType CapasityType { get; set; } = Enums.CapasityType.Individual;

        public override string ToString()
        {
            var _resource = new ResourceManager(typeof(resource.Resource));
            return $"{_resource.GetString(Type.ToString())} {System} ({Capasity} {_resource.GetString(CapasityType.ToString())})";
            //return base.ToString();
        }

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
            if (string.IsNullOrEmpty(System))
            {
                yield return new ValidationResult(string.Format(Resource._0CanntBeEmpty, nameof(System)), new[] { nameof(System) });
            }

            if (Capasity < 1)
            {
                yield return new ValidationResult(string.Format(Resource._0CanntBeEmpty, nameof(Capasity)), new[] { nameof(Capasity) });
            }
        }

        #endregion Validation
    }
}