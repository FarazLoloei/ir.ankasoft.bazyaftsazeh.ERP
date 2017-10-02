using System.Collections.Generic;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Manage
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}