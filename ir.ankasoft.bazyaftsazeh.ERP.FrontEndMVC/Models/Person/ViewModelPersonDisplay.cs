using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Person
{
    public class ViewModelPersonDisplay
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        [Display(Name = nameof(Name), ResourceType = typeof(Resource))]
        public string Name { get; set; }

        [Display(Name = nameof(Family), ResourceType = typeof(Resource))]
        public string Family { get; set; }
    }
}