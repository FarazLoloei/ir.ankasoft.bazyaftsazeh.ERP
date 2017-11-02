using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Organization
{
    public class ViewModelModifyOrganization
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLenght100", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(Title), ResourceType = typeof(Resource))]
        public string Title { get; set; }

        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(20, ErrorMessageResourceName = "MaxLenght20", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(RegistrationNumber), ResourceType = typeof(Resource))]
        public string RegistrationNumber { get; set; }

        [MaxLength(100, ErrorMessageResourceName = "MaxLenght100", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(RegistrationPlace), ResourceType = typeof(Resource))]
        public string RegistrationPlace { get; set; }

        [MaxLength(20, ErrorMessageResourceName = "MaxLenght20", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(CommercialNumber), ResourceType = typeof(Resource))]
        public string CommercialNumber { get; set; }
    }
}