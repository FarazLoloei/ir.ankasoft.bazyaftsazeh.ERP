using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;

namespace ir.ankasoft.entities.Enums
{
    public enum PersonalTitle : long
    {
        [Display(Name = nameof(Mr), ResourceType = typeof(Resource))]
        Mr = 1,

        [Display(Name = nameof(Mrs), ResourceType = typeof(Resource))]
        Mrs,

        [Display(Name = nameof(Company), ResourceType = typeof(Resource))]
        Company,

        [Display(Name = nameof(TransportCompany), ResourceType = typeof(Resource))]
        TransportCompany,

        [Display(Name = nameof(Organization), ResourceType = typeof(Resource))]
        Organization
    }
}