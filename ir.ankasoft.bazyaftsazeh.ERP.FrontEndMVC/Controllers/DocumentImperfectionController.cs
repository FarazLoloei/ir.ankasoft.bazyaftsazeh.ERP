using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentImperfection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers
{
    public partial class DocumentImperfectionController : Controller
    {
        // GET: DocumentImprefection
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult ImperfectionDetail(List<ViewModelCreateAndModifyDocumentImperfection> request)
        {
            request = request ?? new List<ViewModelCreateAndModifyDocumentImperfection>();
            var imperfectionList = Common.sessionManager.getImperfection();
            request.Add(new ViewModelCreateAndModifyDocumentImperfection());
            request = request.Select(_ =>
            {
                _.ImperfectionList = imperfectionList;
                return _;
            }).ToList();

            return PartialView(MVC.DocumentImperfection.Views._Repeater, request);
        }
    }
}