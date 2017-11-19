using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Enums
{
    public enum PlanType
    {
        [Display(Name = nameof(Cash), ResourceType = typeof(Resource))]
        Cash = 1,
        [Display(Name = nameof(Replacements), ResourceType = typeof(Resource))]
        Replacements,
        [Display(Name = nameof(Government), ResourceType = typeof(Resource))]
        Government
    }
}