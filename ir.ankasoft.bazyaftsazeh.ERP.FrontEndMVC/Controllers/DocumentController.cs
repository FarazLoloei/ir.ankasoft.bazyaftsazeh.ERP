using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers
{
    public partial class DocumentController : BaseController
    {
        // GET: Document
        public virtual ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            var model = new ViewModelCreateDocument();
            return View(model);
        }
    }
}