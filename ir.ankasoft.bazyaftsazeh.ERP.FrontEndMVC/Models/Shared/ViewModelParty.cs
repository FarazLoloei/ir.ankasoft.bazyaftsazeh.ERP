using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models
{
    public class ViewModelCounterParty
    {
        public long recId { get; set; }

        [Display(Name = nameof(Resource.CounterParty), ResourceType = typeof(Resource))]
        public string FullName { get; set; }
    }
}