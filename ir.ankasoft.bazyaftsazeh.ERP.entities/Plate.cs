using ir.ankasoft.entities;
using ir.ankasoft.infrastructure;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Resources;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities
{
    public class Plate : DomainEntity<long>, IDateTracking, IUserTracking
    {
        [Required]
        [MaxLength(20)]
        public string Number { get; set; }

        [Required]
        public Enums.PlateAlphabets Series { get; set; }

        [Required]
        public Enums.PlateColors Color { get; set; }

        [Required]
        public Enums.PlateShapes Shape { get; set; }

        public override string ToString()
        {
            
            var _number = Number.Split('-').ToList();
            if (_number.Count() > 1)
                return $"{_number[1]} {new ResourceManager(typeof(resource.Resource)).GetString(Series.ToString())} {_number[0]}";
            else
                return $"{Number}";
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
            if (string.IsNullOrEmpty(Number))
            {
                yield return new ValidationResult(string.Format(Resource._0CanntBeEmpty, nameof(Number)), new[] { nameof(Number) });
            }
        }

        #endregion Validation
    }
}