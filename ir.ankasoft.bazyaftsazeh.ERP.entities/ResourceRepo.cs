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
    public class ResourceRepo : DomainEntity<long>, IDateTracking, IUserTracking
    {
        public long DocumentStatusRefRecId { get; set; }

        [ForeignKey(nameof(DocumentStatusRefRecId))]
        public DocumentStatus DocumentStatus { get; set; }

        public bool IsConfirmed { get; set; } = false;

        public string FileOriginalTitle { get; set; }

        private string _title = Guid.NewGuid().ToString();
        [MaxLength(36)]
        public string TitleGUID
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    _title = Guid.NewGuid().ToString();
                else
                    _title = value;
            }
        }

        public ResourceType Type { get; set; } = ResourceType.File;

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
            if (string.IsNullOrEmpty(FileOriginalTitle))
            {
                yield return new ValidationResult(string.Format(Resource._0CanntBeEmpty, nameof(FileOriginalTitle)), new[] { nameof(FileOriginalTitle) });
            }

            if (string.IsNullOrEmpty(_title))
            {
                yield return new ValidationResult(string.Format(Resource._0CanntBeEmpty, nameof(TitleGUID)), new[] { nameof(TitleGUID) });
            }

        }

        #endregion Validation
    }
}