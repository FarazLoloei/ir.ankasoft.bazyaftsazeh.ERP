using ir.ankasoft.resource;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.ReplacementPlan
{
    public class ViewModelCreateReplacementPlan
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        [Display(Name = nameof(BeneficiaryImporter), ResourceType = typeof(Resource))]
        public long BeneficiaryImporterRecId { get; set; }

        public List<SelectListItem> BeneficiaryImporter { get; set; } = new List<SelectListItem>();

        [Display(Name = "ReplacementVehicle", ResourceType = typeof(Resource))]
        public long ReplacementVehicleRecId { get; set; }

        public List<SelectListItem> ReplacementVehicle { get; set; }

        [Display(Name = nameof(Representor), ResourceType = typeof(Resource))]
        public string RepresentorRecId { get; set; }

        public List<SelectListItem> Representor { get; set; } = new List<SelectListItem>();
    }
}