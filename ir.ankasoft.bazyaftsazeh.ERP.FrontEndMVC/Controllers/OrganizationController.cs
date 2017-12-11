using AutoMapper;
using ir.ankasoft.bazyaftsazeh.ERP.entities;
using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Communication;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Organization;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.PostalAddress;
using ir.ankasoft.entities.Repositories;
using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers
{
    public partial class OrganizationController : BaseController
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ICommunicationRepository _communicationRpository;
        private readonly IPostalAddressRepository _postalAddressRpository;
        private readonly IContextMenuItemRepository _contextMenuItemRepository;
        private IMapper Mapper;

        public OrganizationController(IPartyRepository partyRepository,
                                IOrganizationRepository personRepository,
                                IContextMenuItemRepository contextMenuItemRepository,
                                ICityRepository cityRepository,
                                ICommunicationRepository communicationRpository,
                                IPostalAddressRepository postalAddressRpository,
                                IUnitOfWorkFactory unitOfWorkFactory)
        {
            _organizationRepository = personRepository;
            _contextMenuItemRepository = contextMenuItemRepository;
            _cityRepository = cityRepository;
            _communicationRpository = communicationRpository;
            _postalAddressRpository = postalAddressRpository;
            _unitOfWorkFactory = unitOfWorkFactory;

            Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
        }

        // GET: Organization
        public virtual ActionResult Index(FilterDataSource request)
        {
            Common.sessionManager.getContextMenu(nameof(OrganizationController).Replace(nameof(Controller), string.Empty));

            request.sort = new KeyValuePair<string, tools.SortType>(request.sortBy, (tools.SortType)request.sortType);
            if (Request.IsAjaxRequest())
                return PartialView(MVC.Organization.Views._List,
                                   Load(request));
            return View(Load(request));
        }

        private PagerModel<ViewModelOrganizationDisplay> Load(FilterDataSource request)
        {
            var data = new List<ViewModelOrganizationDisplay>();
            int totalRecords;
            IQueryable<Organization> objects =
                _organizationRepository.LoadByFilter(
                    request, out totalRecords)
                                   .AsQueryable();
            data = Mapper.Map<List<ViewModelOrganizationDisplay>>(objects);
            var model = new PagerModel<ViewModelOrganizationDisplay>
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
            var model = new ViewModelCreateOrganization() { parentId = partyId };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(ViewModelCreateOrganization request,
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
                        var _person = Mapper.Map<Organization>(request);
                        _organizationRepository.Add(_person);
                        return RedirectToAction(MVC.Organization.Index());
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
            Organization _model = _organizationRepository.FindById(id);
            if (_model == null)
            {
                return HttpNotFound();
            }
            var data = Mapper.Map<ViewModelModifyOrganization>(_model);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Modify(ViewModelModifyOrganization request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        Organization _person = _organizationRepository.FindById(request.recId);
                        Mapper.Map(request, _person, typeof(ViewModelModifyOrganization), typeof(Organization));
                        return RedirectToAction(MVC.Organization.Index());
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
                _organizationRepository.Remove(id);
            }
            return RedirectToAction(MVC.Organization.Index());
        }

        [HttpGet]
        public virtual ActionResult CommunicationList(long id)
        {
            Organization _person = _organizationRepository.FindById(id, y => y.Party);
            if (_person == null)
            {
                throw new Exception("ObjectNotFound");
            }
            ViewModelOrganizationCommunication model = Mapper.Map<ViewModelOrganizationCommunication>(_person);
            model.CommunicationCollection = model.CommunicationCollection.Select(_ => { _.ParentId = id; return _; }).ToList();
            model.NationalCode = _person.Party.NationalCode;
            model.PersonalTitle = _person.Party.PersonalTitle;
            model.Title = _person.Title;
            return View(model);
        }

        [HttpGet]
        public virtual ActionResult PostalAddressList(long id)
        {
            Organization _person = _organizationRepository.FindById(id, _ => _.PostalAddressCollection.Select(y => y.Province),
                _ => _.PostalAddressCollection.Select(y => y.City));
            if (_person == null)
            {
                throw new Exception("ObjectNotFound");
            }
            ViewModelOrganizationCommunication model = Mapper.Map<ViewModelOrganizationCommunication>(_person);
            model.PostalAddressCollection = model.PostalAddressCollection.Select(_ => { _.Postal_ParentId = id; return _; }).ToList();
            model.CommunicationCollection = model.CommunicationCollection.Select(_ => { _.ParentId = id; return _; }).ToList();
            model.NationalCode = _person.Party.NationalCode;
            model.PersonalTitle = _person.Party.PersonalTitle;
            model.Title = _person.Title;
            return View(model);
        }
    }
}