using AutoMapper;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Party;
using ir.ankasoft.entities;
using ir.ankasoft.entities.Repositories;
using ir.ankasoft.infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers
{
    public partial class PartyController : BaseController
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IPartyRepository _partyRepository;
        private readonly IContextMenuItemRepository _contextMenuItemRepository;
        private IMapper Mapper;

        public PartyController(IPartyRepository partyRepository,
                               IContextMenuItemRepository contextMenuItemRepository,
                               IUnitOfWorkFactory unitOfWorkFactory)
        {
            _partyRepository = partyRepository;
            _contextMenuItemRepository = contextMenuItemRepository;
            _unitOfWorkFactory = unitOfWorkFactory;


            Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
        }

        // GET: Party
        public virtual ActionResult Index(FilterDataSource request)
        {
            string controllerTitle = nameof(PartyController).Replace("Controller", "");
            if (Session[$"ContextMenu_{controllerTitle}"] == null)
                Session[$"ContextMenu_{controllerTitle}"] = Mapper.Map<List<ViewModelContextMenu>>(_contextMenuItemRepository.GetContextMenu(controllerTitle, false, true));
            if (Session[$"ContextMenu_{controllerTitle}_Header"] == null)
                Session[$"ContextMenu_{controllerTitle}_Header"] = Mapper.Map<List<ViewModelContextMenu>>(_contextMenuItemRepository.GetContextMenu(controllerTitle, true, false));

            request.sort = new KeyValuePair<string, tools.SortType>(request.sortBy, (tools.SortType)request.sortType);
            if (Request.IsAjaxRequest())
                return PartialView(MVC.Party.Views._List,
                                   Load(request));
            return View(Load(request));
        }

        private PagerModel<ViewModelPartyDisplay> Load(FilterDataSource request)
        {
            var data = new List<ViewModelPartyDisplay>();
            int totalRecords;
            IQueryable<Party> parties =
                _partyRepository.LoadByFilter(
                    request, out totalRecords)
                                   .AsQueryable();
            data = Mapper.Map<List<ViewModelPartyDisplay>>(parties);
            var model = new PagerModel<ViewModelPartyDisplay>
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
            return View(new ViewModelCreateParty());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(ViewModelCreateParty request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        var _party = Mapper.Map<Party>(request);
                        _partyRepository.Add(_party);
                        return RedirectToAction(MVC.Party.Index());
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
            Party _party = _partyRepository.FindById(id);
            if (_party == null)
            {
                return HttpNotFound();
            }
            var data = Mapper.Map<ViewModelModifyParty>(_party);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Modify(ViewModelModifyParty request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        Party _party = _partyRepository.FindById(request.recId);
                        Mapper.Map(request, _party, typeof(ViewModelModifyParty), typeof(Party));
                        return RedirectToAction(MVC.Party.Index());
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
                _partyRepository.Remove(id);
            }
            return RedirectToAction(MVC.Party.Index());
        }

        [AllowAnonymous]
        [HttpPost]
        public virtual ActionResult CheckExistingNationalCode(string nationalCode)
        {
            try
            {
                return Json(!_partyRepository.CheckExistingNationalCode(nationalCode), JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}