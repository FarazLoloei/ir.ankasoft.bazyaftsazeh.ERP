using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Dashboard;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Document;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentStatus
{
    public class ViewModelDocumentStatus
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

       public long StatusRecId { get; set; }

        public ViewModelDisplayDocument Document { get; set; } = new ViewModelDisplayDocument();

        [Display(Name = nameof(Description), ResourceType = typeof(Resource))]
        public string Description { get; set; }

        public List<ViewModelOperationsAttribute> AttributesList { get; set; } = new List<ViewModelOperationsAttribute>();
    }
}