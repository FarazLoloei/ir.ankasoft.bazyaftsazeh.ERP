using ir.ankasoft.entities;
using ir.ankasoft.infrastructure;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities
{
    public class Vehicle : DomainEntity<long>, IDateTracking, IUserTracking
    {
        [Required]
        [MaxLength(100)]
        public string Model { get; set; }

        [Required]
        public long VehicleTipRefRecId { get; set; }

        [ForeignKey(nameof(VehicleTipRefRecId))]
        public VehicleTip VehicleTip { get; set; }

        [Required]
        public long PlateRefRecId { get; set; }

        [ForeignKey(nameof(PlateRefRecId))]
        public Plate Plate { get; set; }

        [Required]
        [MaxLength(100)]
        public string Color { get; set; }

        [Required]
        [MaxLength(20)]
        public string ChassisNumber { get; set; }

        [Required]
        [MaxLength(20)]
        public string EngineNumber { get; set; }

        public int CylinderCount { get; set; } = 4;

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
            if (string.IsNullOrEmpty(Model))
            {
                yield return new ValidationResult(string.Format(Resource._0CanntBeEmpty, nameof(Model)), new[] { nameof(Model) });
            }
            if (string.IsNullOrEmpty(Color))
            {
                yield return new ValidationResult(string.Format(Resource._0CanntBeEmpty, nameof(Color)), new[] { nameof(Color) });
            }
            if (string.IsNullOrEmpty(ChassisNumber))
            {
                yield return new ValidationResult(string.Format(Resource._0CanntBeEmpty, nameof(ChassisNumber)), new[] { nameof(ChassisNumber) });
            }
            if (string.IsNullOrEmpty(EngineNumber))
            {
                yield return new ValidationResult(string.Format(Resource._0CanntBeEmpty, nameof(EngineNumber)), new[] { nameof(EngineNumber) });
            }
        }

        #endregion Validation
    }
}