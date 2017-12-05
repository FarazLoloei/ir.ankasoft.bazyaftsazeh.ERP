using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentCost;
using System.Collections.Generic;
using System.Linq;
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

        public virtual ActionResult CostDetail(List<ViewModelCreateAndModifyDocumentCost> request)
        {
            request = request ?? new List<ViewModelCreateAndModifyDocumentCost>();
            var costsList = Common.sessionManager.getCosts();
            request.Add(new ViewModelCreateAndModifyDocumentCost());
            request = request.Select(_ =>
            {
                _.CostList = costsList;
                return _;
            }).ToList();

            return PartialView(MVC.DocumentCost.Views._Repeater, request);
        }
    }
}