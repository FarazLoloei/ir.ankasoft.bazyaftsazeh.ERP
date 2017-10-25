﻿using ir.ankasoft.entities.Enums;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Communication
{
    public class ViewModelCreateModifyCommunication
    {
        [HiddenInput(DisplayValue = false)]
        public long ParentId { get; set; }

        [Display(Name = nameof(PersonalTitle), ResourceType = typeof(Resource))]
        public PersonalTitle PersonalTitle { get; set; }

        [Display(Name = nameof(Title), ResourceType = typeof(Resource))]
        public string Title { get; set; }

        [Display(Name = nameof(NationalCode), ResourceType = typeof(Resource))]
        public string NationalCode { get; set; }
        /* Detail */
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        [Display(Name = nameof(Type), ResourceType = typeof(Resource))]
        public CommunicationType Type { get; set; }

        [Display(Name = nameof(IsPrimary), ResourceType = typeof(Resource))]
        public bool IsPrimary { get; set; } = false;

        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLenght100", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(Value), ResourceType = typeof(Resource))]
        public string Value { get; set; }

        [Display(Name = nameof(Description), ResourceType = typeof(Resource))]
        public string Description { get; set; }
    }
}