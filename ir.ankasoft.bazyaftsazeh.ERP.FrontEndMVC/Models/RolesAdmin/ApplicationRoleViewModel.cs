using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.RolesAdmin
{
    public class ApplicationRoleViewModel
    {
        public long Id { get; set; }

        [Display(Name = nameof(Resource.UserName), ResourceType = typeof(Resource))]
        public string Name { get; set; }

        [Display(Name = nameof(Resource.Description), ResourceType = typeof(Resource))]
        public string Description { get; set; }
    }
}