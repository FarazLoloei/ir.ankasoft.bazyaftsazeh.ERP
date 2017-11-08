using AutoMapper;
using ir.ankasoft.bazyaftsazeh.ERP.entities;
using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Cost;
using ir.ankasoft.entities.Repositories;
using ir.ankasoft.infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers
{
    public partial class CostController : BaseController
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly ICostRepository _costRepository;
        private readonly IPreDefineTitleRepository _preDefineTitleRepository;
        private readonly IContextMenuItemRepository _contextMenuItemRepository;
        private IMapper Mapper;

        public CostController(ICostRepository costRepository,
                              IContextMenuItemRepository contextMenuItemRepository,
                              IPreDefineTitleRepository preDefineTitleRepository,
                              IUnitOfWorkFactory unitOfWorkFactory)
        {
            _costRepository = costRepository;
            _contextMenuItemRepository = contextMenuItemRepository;
            _preDefineTitleRepository = preDefineTitleRepository;
            _unitOfWorkFactory = unitOfWorkFactory;

            Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
        }

        // GET: Party
        public virtual ActionResult Index(FilterDataSource request)
        {
            Common.sessionManager.getContextMenu(nameof(CostController).Replace(nameof(Controller), string.Empty));

            request.sort = new KeyValuePair<string, tools.SortType>(request.sortBy, (tools.SortType)request.sortType);
            if (Request.IsAjaxRequest())
                return PartialView(MVC.Cost.Views._List,
                                   Load(request));
            return View(Load(request));
        }

        private PagerModel<ViewModelCostDisplay> Load(FilterDataSource request)
        {
            var data = new List<ViewModelCostDisplay>();
            int totalRecords;
            IQueryable<Cost> entities =
                _costRepository.LoadByFilter(
                    request, out totalRecords)
                                   .AsQueryable();
            data = Mapper.Map<List<ViewModelCostDisplay>>(entities);
            var model = new PagerModel<ViewModelCostDisplay>
            {
                Data = data,
                PageData = new PagerData
                {
                    filterDataSource = request,
                    TotalRows = totalRecords,
                },
            };
            return model;
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            return View(new ViewModelCreateAndModifyCost());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(ViewModelCreateAndModifyCost request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        var _titleObject = _preDefineTitleRepository.FindByTitle(request.Title);
                        var _model = Mapper.Map<Cost>(request);
                        if (_titleObject != null)
                            _model.PreDefineTitleRefRecId = _titleObject.recId;
                        else
                            _model.Title = new PreDefineTitle()
                            {
                                Title = request.Title,
                                Type = entities.Enums.TitleType.Cost
                            };
                        _costRepository.Add(_model);
                        return RedirectToAction(MVC.Cost.Index());
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

        public virtual ActionResult Modify(long id)
        {
            Cost _model = _costRepository.FindById(id, y => y.Title);
            if (_model == null)
            {
                return HttpNotFound();
            }
            var data = Mapper.Map<ViewModelCreateAndModifyCost>(_model);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Modify(ViewModelCreateAndModifyCost request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        var _titleObject = _preDefineTitleRepository.FindByTitle(request.Title);
                        Cost _model = _costRepository.FindById(request.recId);
                        Mapper.Map(request, _model, typeof(ViewModelCreateAndModifyCost), typeof(Cost));
                        if (_titleObject == null)
                            _model.Title = new PreDefineTitle()
                            {
                                Title = request.Title,
                                Type = entities.Enums.TitleType.Cost
                            };
                        return RedirectToAction(MVC.Cost.Index());
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

        public virtual ActionResult Remove(long id)
        {
            using (_unitOfWorkFactory.Create())
            {
                _costRepository.Remove(id);
            }
            return RedirectToAction(MVC.Cost.Index());
        }
    }
}