using AutoMapper;
using ir.ankasoft.bazyaftsazeh.ERP.entities;
using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Imperfection;
using ir.ankasoft.entities.Repositories;
using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers
{
    public partial class ImperfectionController : BaseController
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IImperfectionRepository _imperfectionRepository;
        private readonly IPreDefineTitleRepository _preDefineTitleRepository;
        private readonly IContextMenuItemRepository _contextMenuItemRepository;
        private IMapper Mapper;

        public ImperfectionController(IImperfectionRepository ImperfectionRepository,
                              IContextMenuItemRepository contextMenuItemRepository,
                              IPreDefineTitleRepository preDefineTitleRepository,
                              IUnitOfWorkFactory unitOfWorkFactory)
        {
            _imperfectionRepository = ImperfectionRepository;
            _contextMenuItemRepository = contextMenuItemRepository;
            _preDefineTitleRepository = preDefineTitleRepository;
            _unitOfWorkFactory = unitOfWorkFactory;

            Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
        }

        // GET: Party
        public virtual ActionResult Index(FilterDataSource request)
        {
            Common.sessionManager.getContextMenu(nameof(ImperfectionController).Replace(nameof(Controller), string.Empty));

            request.sort = new KeyValuePair<string, tools.SortType>(request.sortBy, (tools.SortType)request.sortType);
            if (Request.IsAjaxRequest())
                return PartialView(MVC.Imperfection.Views._List,
                                   Load(request));
            return View(Load(request));
        }

        private PagerModel<ViewModelImperfectionDisplay> Load(FilterDataSource request)
        {
            var data = new List<ViewModelImperfectionDisplay>();
            int totalRecords;
            IQueryable<Imperfection> entities =
                _imperfectionRepository.LoadByFilter(
                    request, out totalRecords)
                                   .AsQueryable();
            data = Mapper.Map<List<ViewModelImperfectionDisplay>>(entities);
            var model = new PagerModel<ViewModelImperfectionDisplay>
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
            return View(new ViewModelCreateAndModifyImperfection());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(ViewModelCreateAndModifyImperfection request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        var _titleObject = _preDefineTitleRepository.FindByTitle(request.Title);
                        var _model = Mapper.Map<Imperfection>(request);
                        if (_titleObject != null)
                            _model.PreDefineTitleRefRecId = _titleObject.recId;
                        else
                            _model.Title = new PreDefineTitle()
                            {
                                Title = request.Title,
                                Type = entities.Enums.TitleType.Imperfection
                            };
                        _imperfectionRepository.Add(_model);
                        return RedirectToAction(MVC.Imperfection.Index());
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
            Imperfection _model = _imperfectionRepository.FindById(id, y => y.Title);
            if (_model == null)
            {
                return HttpNotFound();
            }
            var data = Mapper.Map<ViewModelCreateAndModifyImperfection>(_model);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Modify(ViewModelCreateAndModifyImperfection request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        var _titleObject = _preDefineTitleRepository.FindByTitle(request.Title);
                        Imperfection _model = _imperfectionRepository.FindById(request.recId);
                        Mapper.Map(request, _model, typeof(ViewModelCreateAndModifyImperfection), typeof(Imperfection));
                        if (_titleObject == null)
                            _model.Title = new PreDefineTitle()
                            {
                                Title = request.Title,
                                Type = entities.Enums.TitleType.Imperfection
                            };
                        return RedirectToAction(MVC.Imperfection.Index());
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
                _imperfectionRepository.Remove(id);
            }
            return RedirectToAction(MVC.Imperfection.Index());
        }
    }
}