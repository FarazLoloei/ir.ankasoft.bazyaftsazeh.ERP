using ir.ankasoft.bazyaftsazeh.ERP.entities.Enums;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.VehiclePlate;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Vehicle
{
    public class ViewModelCreateAndModifyVehicle
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        [Display(Name = nameof(Model), ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(4, ErrorMessageResourceName = "MaxLenght100", ErrorMessageResourceType = typeof(Resource))]
        public string Model { get; set; }

        public long PlateRecId { get; set; }

        [Display(Name = nameof(Color), ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLenght100", ErrorMessageResourceType = typeof(Resource))]
        public string Color { get; set; }

        [Display(Name = nameof(ChassisNumber), ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLenght100", ErrorMessageResourceType = typeof(Resource))]
        public string ChassisNumber { get; set; }

        [Display(Name = nameof(EngineNumber), ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLenght100", ErrorMessageResourceType = typeof(Resource))]
        public string EngineNumber { get; set; }

        [Display(Name = nameof(CylinderCount), ResourceType = typeof(Resource))]
        public CylinderCounts CylinderCount { get; set; } = CylinderCounts.C4;

        [Display(Name = nameof(VehicleTip), ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        public long VehicleTipRecId { get; set; }

        public List<SelectListItem> VehicleTip { get; set; } = new List<SelectListItem>();

        public ViewModelCreateAndModifyVehiclePlate Plate { get; set; }
    }
}