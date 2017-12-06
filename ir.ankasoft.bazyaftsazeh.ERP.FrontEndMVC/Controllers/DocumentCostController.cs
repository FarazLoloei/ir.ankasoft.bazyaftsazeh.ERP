using AutoMapper;
using ir.ankasoft.bazyaftsazeh.ERP.entities;
using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentCost;
using ir.ankasoft.infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers
{
    public partial class DocumentCostController : Controller
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IDocumentCostRepository _documentCostRpository;
        private IMapper Mapper;

        public DocumentCostController(IDocumentCostRepository documentCostRpository,
                                      IUnitOfWorkFactory unitOfWorkFactory)
        {
            _documentCostRpository = documentCostRpository;
            _unitOfWorkFactory = unitOfWorkFactory;

            Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
        }

        // GET: DocumentCost
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult CostDetail(List<ViewModelCreateAndModifyDocumentCost> request)
        {
            request = request ?? new List<ViewModelCreateAndModifyDocumentCost>();
            var costsList = Common.sessionManager.getCosts(true);
            request.Add(new ViewModelCreateAndModifyDocumentCost());
            request = request.Select(_ =>
            {
                _.CostList = costsList;
                return _;
            }).ToList();

            return PartialView(MVC.DocumentCost.Views._Repeater, request);
        }

        [HttpGet]
        public virtual ActionResult CreateDocumentCost(long parentId)
        {
            var model = new ViewModelCreateAndModifyDocumentCost()
            {
                CostList = Common.sessionManager.getCosts(false)
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult CreateDocumentCost(ViewModelCreateAndModifyDocumentCost request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        var _documentCost = Mapper.Map<DocumentCost>(request);

                        _documentCostRpository.Add(_documentCost);
                        return RedirectToAction(MVC.Document.CostList(request.ParentId));
                    }
                }
                catch (ModelValidationException modelValidationException)
                {
                    foreach (var error in modelValidationException.ValidationErrors)
                    {
                        ModelState.AddModelError(error.MemberNames.FirstOrDefault() ?? string.Empty, error.ErrorMessage);
                    }
                }
            }

            return View(request);
        }

        [HttpGet]
        public virtual ActionResult ModifyDocumentCost(long parentId, long documentCostId)
        {
            DocumentCost _model = _documentCostRpository.FindById(documentCostId, x => x.Title);
            if (_model == null)
            {
                return HttpNotFound();
            }
            var data = Mapper.Map<ViewModelCreateAndModifyDocumentCost>(_model);
            data.CostList = Common.sessionManager.getCosts(false);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult ModifyDocumentCost(ViewModelCreateAndModifyDocumentCost request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        DocumentCost _documentCost = _documentCostRpository.FindById(request.CostRecId);
                        Mapper.Map(request, _documentCost, typeof(ViewModelCreateAndModifyDocumentCost), typeof(DocumentCost));
                        return RedirectToAction(MVC.Document.CostList(request.ParentId));
                    }
                }
                catch (ModelValidationException modelValidationException)
                {
                    foreach (var error in modelValidationException.ValidationErrors)
                    {
                        ModelState.AddModelError(error.MemberNames.FirstOrDefault() ?? string.Empty, error.ErrorMessage);
                    }
                }
            }
            return View(request);
        }
    }
}