using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Person
{
    public class ViewModelPersonDisplay
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        [Display(Name = nameof(NationalCode), ResourceType = typeof(Resource))]
        public string NationalCode { get; set; }

        [Display(Name = nameof(Name), ResourceType = typeof(Resource))]
        public string Name { get; set; }

        [Display(Name = nameof(Family), ResourceType = typeof(Resource))]
        public string Family { get; set; }

        [Display(Name = nameof(Telephone), ResourceType = typeof(Resource))]
        public string Telephone { get; set; }

        [Display(Name = nameof(Mobile), ResourceType = typeof(Resource))]
        public string Mobile { get; set; }
    }
}