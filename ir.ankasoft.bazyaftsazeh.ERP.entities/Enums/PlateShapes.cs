using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Enums
{
    public enum PlateShapes : int
    {
        //[Display(Name = nameof(Personal), ResourceType = typeof(Resource))]
        //Personal = 1 ,
        //[Display(Name = nameof(Taxi), ResourceType = typeof(Resource))]
        //Taxi,
        //[Display(Name = nameof(Government), ResourceType = typeof(Resource))]
        //Government,
        //[Display(Name = nameof(Political), ResourceType = typeof(Resource))]
        //Political,
        //[Display(Name = nameof(Military), ResourceType = typeof(Resource))]
        //Military

        [Display(Name = nameof(Local), ResourceType = typeof(Resource))]
        Local = 1,

        [Display(Name = nameof(TwoColor_Tehran), ResourceType = typeof(Resource))]
        TwoColor_Tehran,

        [Display(Name = nameof(TwoColor_OtherCity), ResourceType = typeof(Resource))]
        TwoColor_OtherCity,

        [Display(Name = nameof(Old), ResourceType = typeof(Resource))]
        Old,

        [Display(Name = nameof(OneColor_Numeric), ResourceType = typeof(Resource))]
        OneColor_Numeric,

        [Display(Name = nameof(OneColor_Alphabetic), ResourceType = typeof(Resource))]
        OneColor_Alphabetic,

        [Display(Name = nameof(MotoCycle_Iran), ResourceType = typeof(Resource))]
        MotoCycle_Iran,

        [Display(Name = nameof(MotoCycle_Old), ResourceType = typeof(Resource))]
        MotoCycle_Old
    }
}