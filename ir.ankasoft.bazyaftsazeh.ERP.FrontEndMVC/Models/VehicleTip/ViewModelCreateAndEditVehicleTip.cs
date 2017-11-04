using ir.ankasoft.bazyaftsazeh.ERP.entities.Enums;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.VehicleTip
{
    public class ViewModelCreateAndEditVehicleTip
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLenght100", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(System), ResourceType = typeof(Resource))]
        public string System{ get; set; }

        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(Type), ResourceType = typeof(Resource))]
        public VehicleType Type { get; set; }
        
        [Display(Name = nameof(Capasity), ResourceType = typeof(Resource))]
        public long Capasity { get; set; } = 4;

        [Display(Name = "MeasuringUnit", ResourceType = typeof(Resource))]
        public CapasityType CapasityType { get; set; }
        

    }
}