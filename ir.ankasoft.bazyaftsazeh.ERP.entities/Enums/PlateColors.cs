using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Enums
{
    public enum PlateColors : int
    {
        [Display(Name = nameof(White), ResourceType = typeof(Resource))]
        White = 1,

        [Display(Name = nameof(Red), ResourceType = typeof(Resource))]
        Red,

        [Display(Name = nameof(Yellow), ResourceType = typeof(Resource))]
        Yellow,

        [Display(Name = nameof(Blue), ResourceType = typeof(Resource))]
        Blue,

        [Display(Name = nameof(Green), ResourceType = typeof(Resource))]
        Green
    }
}