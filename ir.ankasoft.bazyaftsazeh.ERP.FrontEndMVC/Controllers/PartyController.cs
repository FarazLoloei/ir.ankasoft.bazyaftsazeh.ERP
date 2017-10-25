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
            _cityRepository = cityRepository;
            _communicationRpository = communicationRpository;
            _postalAddressRpository = postalAddressRpository;
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

        /*Communication*/

        #region Communication
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
        public virtual ActionResult CreateCommunication(long parentId)
        {
            return View(new ViewModelCreateModifyCommunication() { ParentId = parentId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult CreateCommunication(ViewModelCreateModifyCommunication request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        var _communication = Mapper.Map<Communication>(request);
                        _communication.PartyRefRecId = request.ParentId;
                        _communicationRpository.Add(_communication);
                        return RedirectToAction(MVC.Party.CommunicationList(request.ParentId));
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
        public virtual ActionResult ModifyCommunication(long parentId, long communicationId)
        {
            Party _party = _partyRepository.FindById(parentId);
            Communication _model = _communicationRpository.FindById(communicationId);
            if (_model == null)
            {
                return HttpNotFound();
            }
            var data = Mapper.Map<ViewModelCreateModifyCommunication>(_model);
            data.ParentId = parentId;
            data.PersonalTitle = _party.PersonalTitle;
            data.Title = _party.Title;
            data.NationalCode = _party.NationalCode;
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult ModifyCommunication(ViewModelCreateModifyCommunication request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        Communication _communication = _communicationRpository.FindById(request.recId);
                        Mapper.Map(request, _communication, typeof(ViewModelCreateModifyCommunication), typeof(Communication));
                        return RedirectToAction(MVC.Party.CommunicationList(request.ParentId));
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

        //public virtual ActionResult RemoveCommunication(long id, long parentId)
        //{
        //    _communicationRpository.Remove(id);
        //    return RedirectToAction(MVC.Party.CommunicationList(parentId));
        //} 
        #endregion

        #region PostalAddress

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
            model.PostalAddressCollection = model.PostalAddressCollection.Select(_ => { _.ParentId = id; return _; }).ToList();
            return View(model);
        }

        [HttpGet]
        public virtual ActionResult CreatePostalAddress(long parentId)
        {
            Party _party = _partyRepository.FindById(parentId);

            var model = new ViewModelCreateModifyPostalAddress()
            {

                ParentId = parentId,
                PersonalTitle = _party.PersonalTitle,
                Title = _party.Title,
                NationalCode = _party.NationalCode,
                ProvinceCityList = _cityRepository.GetProvinceCity(string.Empty).Select(_ =>
                {
                    return new SelectListItem() { Text = _.Item1, Value = _.Item2 };
                }).ToList()};

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult CreatePostalAddress(ViewModelCreateModifyPostalAddress request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        var _postalAddress = Mapper.Map<PostalAddress>(request);
                        _postalAddress.PartyRefRecId = request.ParentId;
                        _postalAddressRpository.Add(_postalAddress);
                        return RedirectToAction(MVC.Party.PostalAddressList(request.ParentId));
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
        public virtual ActionResult ModifyPostalAddress(long parentId, long communicationId)
        {
            Party _party = _partyRepository.FindById(parentId);
            PostalAddress _model = _postalAddressRpository.FindById(communicationId, _ => _.Province, _ => _.City);
            if (_model == null)
            {
                return HttpNotFound();
            }
            var data = Mapper.Map<ViewModelCreateModifyPostalAddress>(_model);
            data.ParentId = parentId;
            data.PersonalTitle = _party.PersonalTitle;
            data.Title = _party.Title;
            data.NationalCode = _party.NationalCode;
            data.ProvinceCityList = _cityRepository.GetProvinceCity(string.Empty).Select(_ =>
           {
               return new SelectListItem() { Text = _.Item1, Value = _.Item2 };
           }).ToList();
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult ModifyPostalAddress(ViewModelCreateModifyPostalAddress request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        PostalAddress _postalAddress = _postalAddressRpository.FindById(request.recId);
                        Mapper.Map(request, _postalAddress, typeof(ViewModelCreateModifyPostalAddress), typeof(PostalAddress));
                        return RedirectToAction(MVC.Party.PostalAddressList(request.ParentId));
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

        #endregion

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