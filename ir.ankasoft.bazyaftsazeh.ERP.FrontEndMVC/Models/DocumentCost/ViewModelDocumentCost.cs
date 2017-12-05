using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentCost
{
    public class ViewModelDocumentCost
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        //[Display(Name = nameof(PersonalTitle), ResourceType = typeof(Resource))]
        //public PersonalTitle PersonalTitle { get; set; }

        //[Display(Name = nameof(Title), ResourceType = typeof(Resource))]
        //public string Title { get; set; }

        //[Display(Name = nameof(NationalCode), ResourceType = typeof(Resource))]
        //public string NationalCode { get; set; }

        public List<ViewModelDisplayDocumentCost> CostCollection { get; set; }
    }
}