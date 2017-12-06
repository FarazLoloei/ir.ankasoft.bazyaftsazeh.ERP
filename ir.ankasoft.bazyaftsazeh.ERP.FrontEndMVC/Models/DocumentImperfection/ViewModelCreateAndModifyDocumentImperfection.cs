using ir.ankasoft.resource;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentImperfection
{
    public class ViewModelCreateAndModifyDocumentImperfection
    {
        [HiddenInput(DisplayValue = false)]
        public long ParentId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public long ImperfectionRecId { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Resource))]
        public string ImperfectionTitle { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Resource))]
        public long ImperfectionTitleRecId { get; set; }

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