using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Enums
{
    public enum CapasityType : int
    {
        [Display(Name = nameof(KG), ResourceType = typeof(Resource))]
        KG = 1,
        [Display(Name = nameof(Individual), ResourceType = typeof(Resource))]
        Individual
    }
}