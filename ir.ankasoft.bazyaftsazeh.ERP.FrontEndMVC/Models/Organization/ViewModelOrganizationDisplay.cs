using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Organization
{
    public class ViewModelOrganizationDisplay
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        [Display(Name = nameof(NationalCode), ResourceType = typeof(Resource))]
        public string NationalCode { get; set; }

        [Display(Name = nameof(Title), ResourceType = typeof(Resource))]
        public string Title { get; set; }

        [Display(Name = nameof(RegistrationNumber), ResourceType = typeof(Resource))]
        public string RegistrationNumber { get; set; }

        [Display(Name = nameof(RegistrationPlace), ResourceType = typeof(Resource))]
        public string RegistrationPlace { get; set; }

        [Display(Name = nameof(CommercialNumber), ResourceType = typeof(Resource))]
        public string CommercialNumber { get; set; }

        [Display(Name = nameof(Telephone), ResourceType = typeof(Resource))]
        public string Telephone { get; set; }

        [Display(Name = nameof(Mobile), ResourceType = typeof(Resource))]
        public string Mobile { get; set; }
    }
}