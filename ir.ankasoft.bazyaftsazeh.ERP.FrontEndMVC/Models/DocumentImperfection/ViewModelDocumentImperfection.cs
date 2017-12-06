using System.Collections.Generic;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentImperfection
{
    public class ViewModelDocumentImperfection
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        public List<ViewModelDisplayDocumentImperfection> ImperfectionCollection { get; set; }
    }
}