﻿using ir.ankasoft.entities.Enums;
using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Party
{
    public class ViewModelModifyParty
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        [Display(Name = nameof(PersonalTitle), ResourceType = typeof(Resource))]
        public PersonalTitle PersonalTitle { get; set; }

        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLenght100", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(Title), ResourceType = typeof(Resource))]
        public string Title { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = "MustInsertInNumerical", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(NationalCode), ResourceType = typeof(Resource))]
        public string NationalCode { get; set; }

        [Display(Name = nameof(Description), ResourceType = typeof(Resource))]
        public string Description { get; set; }
    }
}