using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Enums
{
    public enum DataType : int
    {
        //[Display(Name = nameof(KG), ResourceType = typeof(Resource))]
        Boolean = 1,

        //[Display(Name = nameof(Individual), ResourceType = typeof(Resource))]
        String
    }
}