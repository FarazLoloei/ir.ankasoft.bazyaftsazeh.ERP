using ir.ankasoft.bazyaftsazeh.ERP.entities.Enums;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.VehiclePlate
{
    public class ViewModelCreateAndModifyVehiclePlate
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(10, ErrorMessageResourceName = "MaxLenght100", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(Number), ResourceType = typeof(Resource))]
        public string Number { get; set; }

        [Display(Name = nameof(Series), ResourceType = typeof(Resource))]
        public PlateAlphabets Series { get; set; }

        [Display(Name = nameof(Color), ResourceType = typeof(Resource))]
        public PlateColors Color { get; set; }

        [Display(Name = nameof(Shape), ResourceType = typeof(Resource))]
        public PlateShapes Shape { get; set; }
    }
}