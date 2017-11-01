using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Importer
{
    public class ViewModelModifyImporter
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLenght100", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(Name), ResourceType = typeof(Resource))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLenght100", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(Family), ResourceType = typeof(Resource))]
        public string Family { get; set; }

        [MaxLength(100, ErrorMessageResourceName = "MaxLenght20", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(ImporterNumber), ResourceType = typeof(Resource))]
        public string ImporterNumber { get; set; }
    }
}