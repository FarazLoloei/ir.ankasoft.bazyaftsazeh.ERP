using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Enums
{
    public enum PaymentType
    {
        [Display(Name = nameof(Cash), ResourceType = typeof(Resource))]
        Cash = 1,
        [Display(Name = nameof(Cheque), ResourceType = typeof(Resource))]
        Cheque
    }
}