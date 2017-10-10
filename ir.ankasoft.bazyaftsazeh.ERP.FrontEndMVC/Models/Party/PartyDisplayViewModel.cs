using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Party
{
    public class PartyDisplayViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        [Display(Name = nameof(Title), ResourceType = typeof(Resource))]
        public string Title { get; set; }

        [Display(Name = nameof(NationalCode), ResourceType = typeof(Resource))]
        public string NationalCode { get; set; }

        [Display(Name = nameof(Description), ResourceType = typeof(Resource))]
        public string Description { get; set; }

        [Display(Name = nameof(Roles), ResourceType = typeof(Resource))]
        public string Roles { get; set; }

        [Display(Name = nameof(Telephone), ResourceType = typeof(Resource))]
        public string Telephone { get; set; }

        [Display(Name = nameof(Mobile), ResourceType = typeof(Resource))]
        public string Mobile { get; set; }
    }
}