using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Enums
{
    public enum DocumentPaymentType
    {
        [Display(Name = nameof(SameDay), ResourceType = typeof(Resource))]
        SameDay = 1,
        [Display(Name = nameof(A_Week), ResourceType = typeof(Resource))]
        A_Week,
        [Display(Name = nameof(TenDays), ResourceType = typeof(Resource))]
        TenDays,
        [Display(Name = nameof(TwoWeeks), ResourceType = typeof(Resource))]
        TwoWeeks,
        [Display(Name = nameof(A_Month), ResourceType = typeof(Resource))]
        A_Month,
        [Display(Name = nameof(Custom), ResourceType = typeof(Resource))]
        Custom
    }
}