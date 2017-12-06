using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentImperfection
{
    public class ViewModelDisplayDocumentImperfection
    {
        [HiddenInput(DisplayValue = false)]
        public long ParentId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Resource))]
        public string ImperfectionTitle { get; set; }

        [Display(Name = "Value", ResourceType = typeof(Resource))]
        public double ImperfectionValue { get; set; }

        [Display(Name = "Value", ResourceType = typeof(Resource))]
        public string ImperfectionValueDisplayMode { get { return tools.Convert.GroupDigiting(ImperfectionValue, 0); } }

        public override string ToString()
        {
            return $"{ImperfectionTitle} - {ImperfectionValueDisplayMode}";
        }
    }
}