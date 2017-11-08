using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers
{
    public partial class DocumentController : Controller
    {
        // GET: Document
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}