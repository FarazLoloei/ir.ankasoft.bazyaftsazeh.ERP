using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Enums
{
    public enum ResourceType : int
    {
        [Display(Name = nameof(File), ResourceType = typeof(Resource))]
        File = 1,

        [Display(Name = nameof(Image), ResourceType = typeof(Resource))]
        Image,

        [Display(Name = nameof(Video), ResourceType = typeof(Resource))]
        Video
    }
}