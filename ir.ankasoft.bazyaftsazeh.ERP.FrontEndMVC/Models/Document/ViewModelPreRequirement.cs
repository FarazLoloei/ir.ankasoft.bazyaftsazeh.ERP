using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Document
{
    public class ViewModelPreRequirement
    {
        public long recId { get; set; }

        public long DocumentRefRecId { get; set; }

        [Display(Name = "BargeSabz", ResourceType = typeof(Resource))]
        public bool HasGreenPaper { get; set; }

        [Display(Name = "Sanad", ResourceType = typeof(Resource))]
        public bool HasSanad { get; set; }

        [Display(Name = "Khalafi", ResourceType = typeof(Resource))]
        public bool HasAdameKhalafi { get; set; }

        [Display(Name = nameof(Description), ResourceType = typeof(Resource))]
        //[Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        public string Description { get; set; }
    }
}