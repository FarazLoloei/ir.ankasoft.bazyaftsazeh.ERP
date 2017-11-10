using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentCost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers
{
    public partial class DocumentCostController : Controller
    {
        // GET: DocumentCost
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult CostDetail(List<ViewModelDisplayDocumentCost> request)
        {
            request = request ?? new List<ViewModelDisplayDocumentCost>();
            request.Add(new ViewModelDisplayDocumentCost());
            return PartialView(MVC.DocumentCost.Views._Repeater, request);
        }
    }
}