using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Enums
{
    public enum PlateShapes:int
    {
        [Display(Name = nameof(Personal), ResourceType = typeof(Resource))]
        Personal = 1 ,
        [Display(Name = nameof(Taxi), ResourceType = typeof(Resource))]
        Taxi,
        [Display(Name = nameof(Government), ResourceType = typeof(Resource))]
        Government,
        [Display(Name = nameof(Political), ResourceType = typeof(Resource))]
        Political,
        [Display(Name = nameof(Military), ResourceType = typeof(Resource))]
        Military
    }
}
