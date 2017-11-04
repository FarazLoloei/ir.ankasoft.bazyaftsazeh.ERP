using ir.ankasoft.bazyaftsazeh.ERP.entities.Enums;
using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.VehicleTip
{
    public class ViewModelVehicleTipDisplay
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        [Display(Name = nameof(System), ResourceType = typeof(Resource))]
        public string System { get; set; }

        [Display(Name = nameof(Type), ResourceType = typeof(Resource))]
        public VehicleType Type { get; set; }

        [Display(Name = nameof(Capasity), ResourceType = typeof(Resource))]
        public long Capasity { get; set; }

        [Display(Name = "MeasuringUnit", ResourceType = typeof(Resource))]
        public CapasityType CapasityType { get; set; }
    }
}