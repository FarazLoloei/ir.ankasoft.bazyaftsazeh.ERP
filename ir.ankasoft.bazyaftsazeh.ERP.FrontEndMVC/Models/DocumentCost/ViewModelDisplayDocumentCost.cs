using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentCost
{
    public class ViewModelDisplayDocumentCost
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        [Display(Name = nameof(Title), ResourceType = typeof(Resource))]
        public string Title { get; set; }

        [Display(Name = nameof(Value), ResourceType = typeof(Resource))]
        public double Value { get; set; }

        [Display(Name = nameof(Value), ResourceType = typeof(Resource))]
        public string ValueDisplayMode { get { return tools.Convert.GroupDigiting(Value, 0); } }

        public override string ToString()
        {
            return $"{Title} - {ValueDisplayMode}";
        }
    }
}