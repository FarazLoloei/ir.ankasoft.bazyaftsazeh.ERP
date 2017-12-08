using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentPayment
{
    public class ViewModelDocumentPayment
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        public List<ViewModelDisplayDocumentPayment> PaymentsCollection { get; set; } = new List<ViewModelDisplayDocumentPayment>();
    }
}