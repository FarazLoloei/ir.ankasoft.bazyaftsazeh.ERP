using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Enums
{
    public enum PlateAlphabets : int
    {
        [Display(Name = nameof(Alef), ResourceType = typeof(Resource))]
        Alef = 1, //الف

        [Display(Name = nameof(Be), ResourceType = typeof(Resource))]
        Be,//ب

        [Display(Name = nameof(Pe), ResourceType = typeof(Resource))]
        Pe,//پ

        [Display(Name = nameof(Te), ResourceType = typeof(Resource))]
        Te,//ت

        [Display(Name = nameof(Jim), ResourceType = typeof(Resource))]
        Jim,//ج

        [Display(Name = nameof(De), ResourceType = typeof(Resource))]
        De,//د

        [Display(Name = nameof(Se), ResourceType = typeof(Resource))]
        Se,//س

        [Display(Name = nameof(Sad), ResourceType = typeof(Resource))]
        Sad, //ص

        [Display(Name = nameof(Ta), ResourceType = typeof(Resource))]
        Ta, //ط

        [Display(Name = nameof(Ge), ResourceType = typeof(Resource))]
        Ge,//ق

        [Display(Name = nameof(Ke), ResourceType = typeof(Resource))]
        Ke,//ک

        [Display(Name = nameof(Ee), ResourceType = typeof(Resource))]
        Ee,//ع

        [Display(Name = nameof(Le), ResourceType = typeof(Resource))]
        Le,//ل

        [Display(Name = nameof(Me), ResourceType = typeof(Resource))]
        Me,//م

        [Display(Name = nameof(Ne), ResourceType = typeof(Resource))]
        Ne,//ن

        [Display(Name = nameof(Ve), ResourceType = typeof(Resource))]
        Ve,//و

        [Display(Name = nameof(He), ResourceType = typeof(Resource))]
        He,//ه

        [Display(Name = nameof(Ye), ResourceType = typeof(Resource))]
        Ye,//ی
    }
}