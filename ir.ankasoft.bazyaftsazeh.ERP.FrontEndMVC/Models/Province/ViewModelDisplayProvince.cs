using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Province
{
    public class ViewModelDisplayProvince
    {
        public long recId { get; set; }

        [Display(Name = nameof(Title), ResourceType = typeof(Resource))]
        public string Title { get; set; }

        [Display(Name = nameof(Abbreviation), ResourceType = typeof(Resource))]
        public string Abbreviation { get; set; }
    }
}