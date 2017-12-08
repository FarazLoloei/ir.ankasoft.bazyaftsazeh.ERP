using AutoMapper;
using ir.ankasoft.bazyaftsazeh.ERP.entities;
using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentImperfection;
using ir.ankasoft.infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers
{
    public partial class DocumentImperfectionController : Controller
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IDocumentImperfectionRepository _documentImperfectionRpository;
        private IMapper Mapper;

        public DocumentImperfectionController(IDocumentImperfectionRepository documentImperfectionRpository,
                                              IUnitOfWorkFactory unitOfWorkFactory)
        {
            _documentImperfectionRpository = documentImperfectionRpository;
            _unitOfWorkFactory = unitOfWorkFactory;

            Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
        }

        // GET: DocumentImprefection
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult ImperfectionDetail(List<ViewModelCreateAndModifyDocumentImperfection> request)
        {
            request = request ?? new List<ViewModelCreateAndModifyDocumentImperfection>();
            var imperfectionList = Common.sessionManager.getImperfections(true);
            request.Add(new ViewModelCreateAndModifyDocumentImperfection());
            request = request.Select(_ =>
            {
                _.ImperfectionList = imperfectionList;
                return _;
            }).ToList();

            return PartialView(MVC.DocumentImperfection.Views._Repeater, request);
        }

        [HttpGet]
        public virtual ActionResult CreateDocumentImperfection(long parentId)
        {
            var model = new ViewModelCreateAndModifyDocumentImperfection()
            {
                ImperfectionList = Common.sessionManager.getImperfections(false)
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult CreateDocumentImperfection(ViewModelCreateAndModifyDocumentImperfection request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        var _ImperfectionCost = Mapper.Map<DocumentImperfection>(request);

                        _documentImperfectionRpository.Add(_ImperfectionCost);
                        return RedirectToAction(MVC.Document.ImperfectionList(request.ParentId));
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
        public virtual ActionResult ModifyDocumentImperfection(long parentId, long documentCostId)
        {
            DocumentImperfection _model = _documentImperfectionRpository.FindById(documentCostId, x => x.Title);
            if (_model == null)
            {
                return HttpNotFound();
            }
            var data = Mapper.Map<ViewModelCreateAndModifyDocumentImperfection>(_model);
            data.ImperfectionList = Common.sessionManager.getImperfections(false);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult ModifyDocumentImperfection(ViewModelCreateAndModifyDocumentImperfection request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        DocumentImperfection _documentImperfection = _documentImperfectionRpository.FindById(request.ImperfectionRecId);
                        Mapper.Map(request, _documentImperfection, typeof(ViewModelCreateAndModifyDocumentImperfection), typeof(DocumentImperfection));
                        return RedirectToAction(MVC.Document.ImperfectionList(request.ParentId));
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