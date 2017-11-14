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

        private readonly ICommunicationRepository _communicationRpository;
        private readonly IPostalAddressRepository _postalAddressRpository;
        private readonly IContextMenuItemRepository _contextMenuItemRepository;
        private IMapper Mapper;

        public PartyController(IPartyRepository partyRepository,
                               IContextMenuItemRepository contextMenuItemRepository,
                               ICityRepository cityRepository,
                               ICommunicationRepository communicationRpository,
                               IPostalAddressRepository postalAddressRpository,
                               IUnitOfWorkFactory unitOfWorkFactory)
        {
            _partyRepository = partyRepository;
            _contextMenuItemRepository = contextMenuItemRepository;
            _communicationRpository = communicationRpository;
            _postalAddressRpository = postalAddressRpository;
            _unitOfWorkFactory = unitOfWorkFactory;

            Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
        }

        // GET: Party
        public virtual ActionResult Index(FilterDataSource request)
        {
            Common.sessionManager.getContextMenu(nameof(PartyController).Replace(nameof(Controller), string.Empty));

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

        public virtual ActionResult GetPartiesList(string searchTerm, int pageSize, int pageNumber)
        {
            var model = _partyRepository.GetPartiesForSelectors(searchTerm);


            //list.Add(new ViewModelSelect2List()
            //{
            //    text = "India",
            //    id = 101
            //});
            //list.Add(new ViewModelSelect2List()
            //{
            //    text = "Srilanka",
            //    id = 102
            //});
            //list.Add(new ViewModelSelect2List()
            //{
            //    text = "Singapore",
            //    id = 103
            //});

            //if (!(string.IsNullOrEmpty(filter) || string.IsNullOrWhiteSpace(filter)))
            //{
            //    list = list.Where(x => x.text.ToLower().StartsWith(filter.ToLower())).ToList();
            //}
            return new JsonNetResult(model, JsonRequestBehavior.AllowGet);
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
            if (communicationCollection != null)
                request.CommunicationCollection = communicationCollection.Where(_ => !string.IsNullOrEmpty(_.Value)).ToList();
            if (postalAddressCollection != null)
            {
                request.PostalAddressCollection = postalAddressCollection.Where(_ => !string.IsNullOrEmpty(_.Postal_Value)).ToList();
                request.PostalAddressCollection = request.PostalAddressCollection.Count() > 0 ? request.PostalAddressCollection : null;
            }
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
            Party _model = _partyRepository.FindById(id);
            if (_model == null)
            {
                return HttpNotFound();
            }
            var data = Mapper.Map<ViewModelModifyParty>(_model);
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

        [HttpGet]
        public virtual ActionResult CommunicationList(long id)
        {
            Party _party = _partyRepository.FindById(id);
            if (_party == null)
            {
                throw new Exception("ObjectNotFound");
            }
            ViewModelPartyCommunication model = Mapper.Map<ViewModelPartyCommunication>(_party);
            model.CommunicationCollection = model.CommunicationCollection.Select(_ => { _.ParentId = id; return _; }).ToList();
            return View(model);
        }

        [HttpGet]
        public virtual ActionResult PostalAddressList(long id)
        {
            Party _party = _partyRepository.FindById(id, _ => _.PostalAddressCollection.Select(y => y.Province),
                _ => _.PostalAddressCollection.Select(y => y.City));
            if (_party == null)
            {
                throw new Exception("ObjectNotFound");
            }
            ViewModelPartyCommunication model = Mapper.Map<ViewModelPartyCommunication>(_party);
            model.PostalAddressCollection = model.PostalAddressCollection.Select(_ => { _.Postal_ParentId = id; return _; }).ToList();
            return View(model);
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