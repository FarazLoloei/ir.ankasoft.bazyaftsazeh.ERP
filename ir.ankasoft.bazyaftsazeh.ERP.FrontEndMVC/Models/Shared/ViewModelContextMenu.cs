using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models
{
    public class ViewModelContextMenu
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        [Display(Name = nameof(Title), ResourceType = typeof(Resource))]
        public string Title { get; set; }

        [Display(Name = nameof(Icon), ResourceType = typeof(Resource))]
        public string Icon { get; set; }

        [Display(Name = nameof(GroupCode), ResourceType = typeof(Resource))]
        public int GroupCode { get; set; }

        [Display(Name = nameof(Priority), ResourceType = typeof(Resource))]
        public int Priority { get; set; }

        private string _disable;

        [Display(Name = nameof(Disable), ResourceType = typeof(Resource))]
        public string Disable
        {
            get
            {
                return _disable.ToLower();
            }
            set
            {
                _disable = value;
            }
        }
    }
}