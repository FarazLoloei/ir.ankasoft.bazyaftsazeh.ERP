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
            Common.sessionManager.getContextMenu(nameof(PersonController).Replace(nameof(Controller), string.Empty));

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
        public virtual ActionResult Create(long partyId = 0)
        {
            if (partyId == 0) return RedirectToAction(MVC.Party.Index());
            var model = new ViewModelCreatePerson() { parentId = partyId };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(ViewModelCreatePerson request,
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
                        Mapper.Map(request, _person, typeof(ViewModelModifyPerson), typeof(Person));
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

        [HttpGet]
        public virtual ActionResult CommunicationList(long id)
        {
            Person _person = _personRepository.FindById(id, y => y.Party);
            if (_person == null)
            {
                throw new Exception("ObjectNotFound");
            }
            ViewModelPersonCommunication model = Mapper.Map<ViewModelPersonCommunication>(_person);
            model.CommunicationCollection = model.CommunicationCollection.Select(_ => { _.ParentId = id; return _; }).ToList();
            model.NationalCode = _person.Party.NationalCode;
            model.PersonalTitle = _person.Party.PersonalTitle;
            model.Title = _person.FullName;
            return View(model);
        }

        [HttpGet]
        public virtual ActionResult PostalAddressList(long id)
        {
            Person _person = _personRepository.FindById(id, _ => _.PostalAddressCollection.Select(y => y.Province),
                _ => _.PostalAddressCollection.Select(y => y.City),
                y => y.Party);
            if (_person == null)
            {
                throw new Exception("ObjectNotFound");
            }
            ViewModelPersonCommunication model = Mapper.Map<ViewModelPersonCommunication>(_person);
            model.PostalAddressCollection = model.PostalAddressCollection.Select(_ => { _.Postal_ParentId = id; return _; }).ToList();
            model.CommunicationCollection = model.CommunicationCollection.Select(_ => { _.ParentId = id; return _; }).ToList();
            model.NationalCode = _person.Party.NationalCode;
            model.PersonalTitle = _person.Party.PersonalTitle;
            model.Title = _person.FullName;
            return View(model);
        }
    }
}