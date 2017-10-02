using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers
{
    [Authorize(Roles = "Admin, Developer")]
    public partial class PagesController : Controller
    {
        // GET: Admin/Pages
        //public ActionResult Index()
        //{
        //    return View();
        //}
        [AllowAnonymous]
        public virtual ActionResult Register()
        {
            return View();
        }

        public virtual ActionResult Error404()
        {
            return View();
        }

        public virtual ActionResult Lock()
        {
            return View();
        }

        public virtual ActionResult Recovery()
        {
            return View();
        }
    }
}