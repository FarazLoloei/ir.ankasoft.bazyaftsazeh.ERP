using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentCost
{
    public class ViewModelCreateAndModifyDocumentCost
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        [Display(Name = nameof(Title), ResourceType = typeof(Resource))]
        public string Title { get; set; }

        [Display(Name = nameof(Value), ResourceType = typeof(Resource))]
        public double Value { get; set; }

        [Display(Name = nameof(Value), ResourceType = typeof(Resource))]
        public string ValueDisplayMode { get { return tools.Convert.GroupDigiting(Value, 0); } }

        public List<SelectListItem> CostList { get; set; }

        public List<SelectListItem> ImperfectionList { get; set; }

        public override string ToString()
        {
            return $"{Title} - {ValueDisplayMode}";
        }
    }
}