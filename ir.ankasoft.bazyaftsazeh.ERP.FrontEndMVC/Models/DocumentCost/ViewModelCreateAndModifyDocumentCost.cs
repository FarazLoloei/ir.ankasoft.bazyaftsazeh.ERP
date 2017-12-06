using ir.ankasoft.resource;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentCost
{
    public class ViewModelCreateAndModifyDocumentCost
    {
        [HiddenInput(DisplayValue = false)]
        public long ParentId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public long CostRecId { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Resource))]
        public string CostTitle { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Resource))]
        public long CostTitleRecId { get; set; }

        [Display(Name = "Value", ResourceType = typeof(Resource))]
        public double CostValue { get; set; }

        [Display(Name = "Value", ResourceType = typeof(Resource))]
        public string CostValueDisplayMode { get { return tools.Convert.GroupDigiting(CostValue, 0); } }

        public List<SelectListItem> CostList { get; set; }

        //public List<SelectListItem> ImperfectionList { get; set; }

        public override string ToString()
        {
            return $"{CostTitle} - {CostValueDisplayMode}";
        }
    }
}