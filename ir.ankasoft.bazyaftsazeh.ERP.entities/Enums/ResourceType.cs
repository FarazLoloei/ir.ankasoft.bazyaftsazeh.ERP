using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Enums
{
    public enum ResourceType : int
    {
        [Display(Name = nameof(Image), ResourceType = typeof(Resource))]
        Image = 1,

        [Display(Name = nameof(Video), ResourceType = typeof(Resource))]
        Video
    }
}