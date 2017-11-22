using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Enums
{
    public enum CylenderCounts : int
    {
        [Display(Name = nameof(C2), ResourceType = typeof(Resource))]
        C2 = 1,

        [Display(Name = nameof(C3), ResourceType = typeof(Resource))]
        C3,

        [Display(Name = nameof(C4), ResourceType = typeof(Resource))]
        C4,

        [Display(Name = nameof(C6), ResourceType = typeof(Resource))]
        C6,

        [Display(Name = nameof(C8), ResourceType = typeof(Resource))]
        C8,

        [Display(Name = nameof(C12), ResourceType = typeof(Resource))]
        C12,

        [Display(Name = nameof(C16), ResourceType = typeof(Resource))]
        C16,
    }
}