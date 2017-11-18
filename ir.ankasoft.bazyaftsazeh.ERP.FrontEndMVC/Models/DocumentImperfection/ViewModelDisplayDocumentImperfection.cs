using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentImperfection
{
    public class ViewModelDisplayDocumentImperfection
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Resource))]
        public string ImperfectionTitle { get; set; }

        [Display(Name = "Value", ResourceType = typeof(Resource))]
        public double ImperfectionValue { get; set; }

        [Display(Name = "Value", ResourceType = typeof(Resource))]
        public string ImperfectionValueDisplayMode { get { return tools.Convert.GroupDigiting(ImperfectionValue, 0); } }

        public List<SelectListItem> ImperfectionList { get; set; }

        public override string ToString()
        {
            return $"{ImperfectionTitle} - {ImperfectionValueDisplayMode}";
        }
    }
}