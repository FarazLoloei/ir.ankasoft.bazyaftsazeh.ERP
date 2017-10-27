using AutoMapper;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Communication;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Person;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.PostalAddress;
using ir.ankasoft.entities;
using ir.ankasoft.entities.Repositories;
using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers
{
    public partial class PersonController : Controller
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IPersonRepository _personRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ICommunicationRepository _communicationRpository;
        private readonly IPostalAddressRepository _postalAddressRpository;
        private readonly IContextMenuItemRepository _contextMenuItemRepository;
        private IMapper Mapper;

        public PersonController(IPartyRepository partyRepository,
                                IPersonRepository personRepository,
                                IContextMenuItemRepository contextMenuItemRepository,
                                ICityRepository cityRepository,
                                ICommunicationRepository communicationRpository,
                                IPostalAddressRepository postalAddressRpository,
                                IUnitOfWorkFactory unitOfWorkFactory)
        {
            _personRepository = personRepository;
            _contextMenuItemRepository = contextMenuItemRepository;
            _cityRepository = cityRepository;
            _communicationRpository = communicationRpository;
            _postalAddressRpository = postalAddressRpository;
            _unitOfWorkFactory = unitOfWorkFactory;

            Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
        }

        // GET: Person
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

        private PagerModel<ViewModelPersonDisplay> Load(FilterDataSource request)
        {
            var data = new List<ViewModelPersonDisplay>();
            int totalRecords;
            IQueryable<Person> parties =
                _personRepository.LoadByFilter(
                    request, out totalRecords)
                                   .AsQueryable();
            data = Mapper.Map<List<ViewModelPersonDisplay>>(parties);
            var model = new PagerModel<ViewModelPersonDisplay>
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
            return View(new ViewModelCreatePerson());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(ViewModelCreatePerson request,
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
                        var _person = Mapper.Map<Person>(request);
                        _personRepository.Add(_person);
                        return RedirectToAction(MVC.Person.Index());
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
            Person _model = _personRepository.FindById(id);
            if (_model == null)
            {
                return HttpNotFound();
            }
            var data = Mapper.Map<ViewModelModifyPerson>(_model);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Modify(ViewModelModifyPerson request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        Person _person = _personRepository.FindById(request.recId);
                        Mapper.Map(request, _person, typeof(ViewModelModifyPerson), typeof(Party));
                        return RedirectToAction(MVC.Person.Index());
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
                _personRepository.Remove(id);
            }
            return RedirectToAction(MVC.Person.Index());
        }

        /*Communication*/

        #region Communication
        [HttpGet]
        public virtual ActionResult CommunicationList(long id)
        {
            Person _person = _personRepository.FindById(id);
            if (_person == null)
            {
                throw new Exception("ObjectNotFound");
            }
            ViewModelPersonCommunication model = Mapper.Map<ViewModelPersonCommunication>(_person);
            model.CommunicationCollection = model.CommunicationCollection.Select(_ => { _.ParentId = id; return _; }).ToList();
            return View(model);
        }

        //[HttpGet]
        //public virtual ActionResult CreateCommunication(long parentId)
        //{
        //    return View(new ViewModelCreateModifyCommunication() { ParentId = parentId });
        //}

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
                        _communication.PersonRefRecId = request.ParentId;
                        _communicationRpository.Add(_communication);
                        return RedirectToAction(MVC.Person.CommunicationList(request.ParentId));
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
            Person _person = _personRepository.FindById(parentId, y => y.Party);
            Communication _model = _communicationRpository.FindById(communicationId);
            if (_model == null)
            {
                return HttpNotFound();
            }
            var data = Mapper.Map<ViewModelCreateModifyCommunication>(_model);
            data.ParentId = parentId;
            data.PersonalTitle = _person.Party.PersonalTitle;
            data.Title = _person.FullName;
            data.NationalCode = _person.Party.NationalCode;
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
                        return RedirectToAction(MVC.Person.CommunicationList(request.ParentId));
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
            Person _person = _personRepository.FindById(id, _ => _.PostalAddressCollection.Select(y => y.Province),
                _ => _.PostalAddressCollection.Select(y => y.City));
            if (_person == null)
            {
                throw new Exception("ObjectNotFound");
            }
            ViewModelPersonCommunication model = Mapper.Map<ViewModelPersonCommunication>(_person);
            model.PostalAddressCollection = model.PostalAddressCollection.Select(_ => { _.ParentId = id; return _; }).ToList();
            return View(model);
        }

        [HttpGet]
        public virtual ActionResult CreatePostalAddress(long parentId)
        {
            Person _person = _personRepository.FindById(parentId, y => y.Party);

            var model = new ViewModelCreateModifyPostalAddress()
            {

                ParentId = parentId,
                PersonalTitle = _person.Party.PersonalTitle,
                Title = _person.FullName,
                NationalCode = _person.Party.NationalCode,
                ProvinceCityList = _cityRepository.GetProvinceCity(string.Empty).Select(_ =>
                {
                    return new SelectListItem() { Text = _.Item1, Value = _.Item2 };
                }).ToList()
            };

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
                        _postalAddress.PersonRefRecId = request.ParentId;
                        _postalAddressRpository.Add(_postalAddress);
                        return RedirectToAction(MVC.Person.PostalAddressList(request.ParentId));
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
            Person _person = _personRepository.FindById(parentId, y => y.Party);
            PostalAddress _model = _postalAddressRpository.FindById(communicationId, _ => _.Province, _ => _.City);
            if (_model == null)
            {
                return HttpNotFound();
            }
            var data = Mapper.Map<ViewModelCreateModifyPostalAddress>(_model);
            data.ParentId = parentId;
            data.PersonalTitle = _person.Party.PersonalTitle;
            data.Title = _person.FullName;
            data.NationalCode = _person.Party.NationalCode;
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
                        return RedirectToAction(MVC.Person.PostalAddressList(request.ParentId));
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