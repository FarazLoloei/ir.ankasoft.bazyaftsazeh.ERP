using ir.ankasoft.entities.Enums;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.PostalAddress
{
    public class ViewModelPostalAddress
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        public bool IsPrimary { get; set; } = false;

        [Display(Name = nameof(Type), ResourceType = typeof(Resource))]
        public PostalAddressType Type { get; set; } = PostalAddressType.Bussiness;

        public long ProvinceRefRecId { get; set; }
        
        public string Province { get; set; }

        public long CityRefRecId { get; set; }
        public string City { get; set; }

        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLenght100", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(Value), ResourceType = typeof(Resource))]
        public string Value { get; set; }

        [StringLength(10)]
        [Display(Name = nameof(PostalCode), ResourceType = typeof(Resource))]
        public string PostalCode { get; set; }


        public List<SelectListItem> ProvinceList { get; set; }
        public List<SelectListItem> CityList { get; set; }
    }
}