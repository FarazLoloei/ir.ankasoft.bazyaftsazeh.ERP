using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentImperfection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers
{
    public partial class DocumentImprefectionController : Controller
    {
        // GET: DocumentImprefection
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult ImprefectionDetail(List<ViewModelDisplayDocumentImperfection> request)
        {
            request = request ?? new List<ViewModelDisplayDocumentImperfection>();
            request.Add(new ViewModelDisplayDocumentImperfection());
            return PartialView(MVC.DocumentImprefection.Views._Repeater, request);
        }
    }
}