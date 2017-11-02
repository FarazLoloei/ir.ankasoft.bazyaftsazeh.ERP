using ir.ankasoft.entities.Enums;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.PostalAddress
{
    public class ViewModelCreateModifyPostalAddress
    {
        [HiddenInput(DisplayValue = false)]
        public long ParentId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public PartyObjective ObjectiveType { get; set; }

        [Display(Name = nameof(PersonalTitle), ResourceType = typeof(Resource))]
        public PersonalTitle PersonalTitle { get; set; }

        [Display(Name = nameof(Title), ResourceType = typeof(Resource))]
        public string Title { get; set; }

        [Display(Name = nameof(NationalCode), ResourceType = typeof(Resource))]
        public string NationalCode { get; set; }

        /* Detail */

        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        [Display(Name = "IsPrimary", ResourceType = typeof(Resource))]
        public bool IsPrimary { get; set; } = false;

        [Display(Name = "Type", ResourceType = typeof(Resource))]
        public PostalAddressType Type { get; set; }

        [Display(Name = nameof(Province), ResourceType = typeof(Resource))]
        public long ProvinceRefRecId { get; set; }

        public string Province { get; set; }

        [Display(Name = nameof(City), ResourceType = typeof(Resource))]
        public long CityRefRecId { get; set; }

        public string City { get; set; }

        [Display(Name = nameof(City), ResourceType = typeof(Resource))]
        public string ProvinceCity
        {
            get
            {
                return $"{CityRefRecId},{ProvinceRefRecId}";
            }
            set
            {
                //if (value.Contains('-'))
                //{
                //    var _value = value.Split('-');
                //    Province = _value[1].Trim();
                //    City = _value[0].Trim();
                //}
                //else
                //{
                var _value = value.Split(',');
                ProvinceRefRecId = Convert.ToInt64(_value[1]);
                CityRefRecId = Convert.ToInt64(_value[0]);
                //}
            }
        }

        [MaxLength(100, ErrorMessageResourceName = "MaxLenght100", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "Value", ResourceType = typeof(Resource))]
        public string Value { get; set; }

        [StringLength(10)]
        [Display(Name = nameof(PostalCode), ResourceType = typeof(Resource))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = "MustInsertInNumerical", ErrorMessageResourceType = typeof(Resource))]
        public string PostalCode { get; set; }

        public List<SelectListItem> ProvinceCityList { get; set; }
    }
}