using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Account
{
    public class ViewModelDisplayUser
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        [Display(Name = nameof(UserName), ResourceType = typeof(Resource))]
        public string UserName { get; set; }

        [Display(Name = nameof(Email), ResourceType = typeof(Resource))]
        public string Email { get; set; }

        [Display(Name = nameof(EmailConfirmed), ResourceType = typeof(Resource))]
        public bool EmailConfirmed { get; set; }

        [Display(Name = nameof(PhoneNumber), ResourceType = typeof(Resource))]
        public string PhoneNumber { get; set; }

        [Display(Name = nameof(PhoneNumberConfirmed), ResourceType = typeof(Resource))]
        public bool PhoneNumberConfirmed { get; set; }
    }
}