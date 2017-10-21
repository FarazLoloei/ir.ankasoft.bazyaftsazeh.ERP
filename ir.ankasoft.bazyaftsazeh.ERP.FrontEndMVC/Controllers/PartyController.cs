using AutoMapper;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Communication;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Party;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.PostalAddress;
using ir.ankasoft.entities;
using ir.ankasoft.entities.Repositories;
using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers
{
    public partial class PartyController : BaseController
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IPartyRepository _partyRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IContextMenuItemRepository _contextMenuItemRepository;
        private IMapper Mapper;

        public PartyController(IPartyRepository partyRepository,
                               IContextMenuItemRepository contextMenuItemRepository,
                               ICityRepository cityRepository,
                               IUnitOfWorkFactory unitOfWorkFactory)
        {
            _partyRepository = partyRepository;
            _contextMenuItemRepository = contextMenuItemRepository;
            _cityRepository = cityRepository;
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
        public virtual ActionResult Create(ViewModelCreateParty request,
            List<ViewModelCommunication> communicationCollection,
            List<ViewModelPostalAddress> postalAddressCollection)
        {
            request.CommunicationCollection = communicationCollection.Where(_ => !string.IsNullOrEmpty(_.Value)).ToList();
            request.PostalAddressCollection = postalAddressCollection.Where(_ => !string.IsNullOrEmpty(_.Postal_Value)).ToList();
            request.PostalAddressCollection = request.PostalAddressCollection.Count() > 0 ? request.PostalAddressCollection : null;
            if (request.PostalAddressCollection == null) { ModelState.Remove("[0].Postal_Value"); }
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
            Party _party = _partyRepository.FindById(id, y => y.CommunicationCollection, y => y.PostalAddressCollection,
                                                                                         y => y.PostalAddressCollection.Select(x => x.Province),
                                                                                         y => y.PostalAddressCollection.Select(x => x.City));
            if (_party == null)
            {
                return HttpNotFound();
            }
            var data = Mapper.Map<ViewModelModifyParty>(_party);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Modify(ViewModelModifyParty request,
            List<ViewModelCommunication> communicationCollection,
            List<ViewModelPostalAddress> postalAddressCollection)
        {
            
            request.CommunicationCollection = communicationCollection.Where(_ => !string.IsNullOrEmpty(_.Value)).ToList();
            request.PostalAddressCollection = postalAddressCollection.Where(_ => !string.IsNullOrEmpty(_.Postal_Value)).ToList();
            request.PostalAddressCollection = request.PostalAddressCollection.Count() > 0 ? request.PostalAddressCollection : null;
            //if (request.PostalAddressCollection == null) { ModelState.Remove("[0].Postal_Value"); }
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

        public virtual ActionResult CommunicationDetail(List<ViewModelCommunication> request)
        {
            request = request ?? new List<ViewModelCommunication>();
            request.Add(new ViewModelCommunication());
            return PartialView(MVC.Communication.Views._Repeater, request);
        }

        public virtual ActionResult PostalAddressDetail(List<ViewModelPostalAddress> request)
        {
            List<SelectListItem> _cityProvinceList = _cityRepository.GetProvinceCity(string.Empty).Select(_ =>
            {
                return new SelectListItem() { Text = _.Item1, Value = _.Item2 };
            }).ToList();

            request = request ?? new List<ViewModelPostalAddress>();
            request.Add(new ViewModelPostalAddress()
            {
                ProvinceCityList = _cityProvinceList
            });
            return PartialView(MVC.PostalAddress.Views._Repeater, request);
        }
    }
}