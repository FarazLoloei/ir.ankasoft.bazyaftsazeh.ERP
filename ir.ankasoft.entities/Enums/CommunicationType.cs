using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;

namespace ir.ankasoft.entities.Enums
{
    public enum CommunicationType
    {
        [Display(Name = nameof(Telephone), ResourceType = typeof(Resource))]
        Telephone = 1,
        [Display(Name = nameof(Mobile), ResourceType = typeof(Resource))]
        Mobile,
        [Display(Name = nameof(Website), ResourceType = typeof(Resource))]
        Website,
        [Display(Name = nameof(Telex), ResourceType = typeof(Resource))]
        Telex,
        [Display(Name = nameof(Fax), ResourceType = typeof(Resource))]
        Fax
    }
}