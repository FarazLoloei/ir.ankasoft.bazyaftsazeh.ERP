using ir.ankasoft.resource;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.GovernmentPlan
{
    public class ViewModelCreateGovernmentPlan
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        [Display(Name = nameof(Representor), ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        public long RepresentorRecId { get; set; }

        public List<SelectListItem> Representor { get; set; } = new List<SelectListItem>();

        [Display(Name = nameof(Organization), ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        public long OrganizationRecId { get; set; }

        public List<SelectListItem> Organization { get; set; } = new List<SelectListItem>();

        [Display(Name = nameof(PermissionNumber), ResourceType = typeof(Resource))]
        public string PermissionNumber { get; set; }
    }
}