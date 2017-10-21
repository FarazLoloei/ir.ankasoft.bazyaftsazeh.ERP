using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;

namespace ir.ankasoft.entities.Enums
{
    public enum PostalAddressType
    {
        [Display(Name = nameof(WorkPlace), ResourceType = typeof(Resource))]
        WorkPlace = 1,
        [Display(Name = nameof(Home), ResourceType = typeof(Resource))]
        Home
    }
}