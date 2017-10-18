using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Cities
{
    public class ViewModelDisplayCity
    {
        public long recId { get; set; }

        [Display(Name = nameof(Title), ResourceType = typeof(Resource))]
        public string Title { get; set; }

        [Display(Name = nameof(Province), ResourceType = typeof(Resource))]
        public string Province { get; set; }
    }
}