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
            var costsList = Common.sessionManager.getCosts();
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

            var model = new ViewModelCreateAndModifyDocumentCost();
            //{
            //    ParentId = parentId,
            //    PersonalTitle = _party.PersonalTitle,
            //    Title = title,
            //    NationalCode = _party.NationalCode,
            //    ObjectiveType = objectiveType
            //};
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
                    //using (_unitOfWorkFactory.Create())
                    //{
                    //    var _communication = Mapper.Map<Communication>(request);

                    //    _communicationRpository.Add(_communication);

                    //}
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

            DocumentCost _model = _documentCostRpository.FindById(documentCostId);
            if (_model == null)
            {
                return HttpNotFound();
            }
            var data = Mapper.Map<ViewModelCreateAndModifyDocumentCost>(_model);
            //data.ParentId = parentId;
            //data.PersonalTitle = _party.PersonalTitle;
            //data.Title = _party.Title;
            //data.NationalCode = _party.NationalCode;
            //data.ObjectiveType = objectiveType;
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
                        //return 
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