using AutoMapper;
using ir.ankasoft.bazyaftsazeh.ERP.entities;
using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.VehicleTip;
using ir.ankasoft.entities.Repositories;
using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers
{
    public partial class VehicleTipController : BaseController
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IVehicleTipRepository _vehicleTipRepository;

        private readonly IContextMenuItemRepository _contextMenuItemRepository;
        private IMapper Mapper;

        public VehicleTipController(IVehicleTipRepository vehicleTipRepository,
                                    IContextMenuItemRepository contextMenuItemRepository,
                                    IUnitOfWorkFactory unitOfWorkFactory)
        {
            _vehicleTipRepository = vehicleTipRepository;
            _contextMenuItemRepository = contextMenuItemRepository;
            _unitOfWorkFactory = unitOfWorkFactory;

            Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
        }

        // GET: Party
        public virtual ActionResult Index(FilterDataSource request)
        {
            Common.sessionManager.getContextMenu(nameof(VehicleTipController).Replace(nameof(Controller), string.Empty));

            request.sort = new KeyValuePair<string, tools.SortType>(request.sortBy, (tools.SortType)request.sortType);
            if (Request.IsAjaxRequest())
                return PartialView(MVC.VehicleTip.Views._List,
                                   Load(request));
            return View(Load(request));
        }

        private PagerModel<ViewModelVehicleTipDisplay> Load(FilterDataSource request)
        {
            var data = new List<ViewModelVehicleTipDisplay>();
            int totalRecords;
            IQueryable<VehicleTip> parties =
                _vehicleTipRepository.LoadByFilter(
                    request, out totalRecords)
                                   .AsQueryable();
            data = Mapper.Map<List<ViewModelVehicleTipDisplay>>(parties);
            var model = new PagerModel<ViewModelVehicleTipDisplay>
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
            return View(new ViewModelCreateAndEditVehicleTip());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(ViewModelCreateAndEditVehicleTip request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        var _vehicleTip = Mapper.Map<VehicleTip>(request);
                        _vehicleTipRepository.Add(_vehicleTip);
                        return RedirectToAction(MVC.VehicleTip.Index());
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
            VehicleTip _model = _vehicleTipRepository.FindById(id);
            if (_model == null)
            {
                return HttpNotFound();
            }
            var data = Mapper.Map<ViewModelCreateAndEditVehicleTip>(_model);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Modify(ViewModelCreateAndEditVehicleTip request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        VehicleTip _vehicleTip = _vehicleTipRepository.FindById(request.recId);
                        Mapper.Map(request, _vehicleTip, typeof(ViewModelCreateAndEditVehicleTip), typeof(VehicleTip));
                        return RedirectToAction(MVC.VehicleTip.Index());
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
                _vehicleTipRepository.Remove(id);
            }
            return RedirectToAction(MVC.Party.Index());
        }
    }
}