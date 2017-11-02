using AutoMapper;
using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.PostalAddress;
using ir.ankasoft.entities;
using ir.ankasoft.entities.Enums;
using ir.ankasoft.entities.Repositories;
using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers
{
    public partial class PostalAddressController : Controller
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IPostalAddressRepository _postalAddressRpository;
        private readonly IPartyRepository _partyRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IImporterRepository _importerRepository;
        private IMapper Mapper;

        public PostalAddressController(IPostalAddressRepository postalAddressRpository,
                                       IPartyRepository partyRepository,
                                       ICityRepository cityRepository,
                                       IPersonRepository personRepository,
                                       IOrganizationRepository organizationRepository,
                                       IImporterRepository importerRepository,
                                       IUnitOfWorkFactory unitOfWorkFactory)
        {
            _postalAddressRpository = postalAddressRpository;
            _partyRepository = partyRepository;
            _cityRepository = cityRepository;
            _personRepository = personRepository;
            _organizationRepository = organizationRepository;
            _importerRepository = importerRepository;
            _unitOfWorkFactory = unitOfWorkFactory;

            Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
        }

        // GET: PostalAddress
        public virtual ActionResult Index()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public virtual ActionResult CreatePostalAddress(long parentId, PartyObjective objectiveType)
        {
            Party _party = null;
            string title = string.Empty;
            switch (objectiveType)
            {
                case PartyObjective.Person:
                    var _person = _personRepository.FindById(parentId, y => y.Party);
                    title = _person.FullName;
                    _party = _person.Party;
                    break;

                case PartyObjective.Importer:
                    var _importer = _importerRepository.FindById(parentId, y => y.Party);
                    title = _importer.FullName;
                    _party = _importer.Party;
                    break;

                case PartyObjective.Organization:
                    var _organization = _organizationRepository.FindById(parentId, y => y.Party);
                    title = _organization.Title;
                    _party = _organization.Party;
                    break;

                default:
                    _party = _partyRepository.FindById(parentId);
                    title = _party.Title;
                    break;
            }
            var model = new ViewModelCreateModifyPostalAddress()
            {
                ParentId = parentId,
                PersonalTitle = _party.PersonalTitle,
                Title = title,
                NationalCode = _party.NationalCode,
                ObjectiveType = objectiveType
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult CreatePostalAddress(ViewModelCreateModifyPostalAddress request, PartyObjective objectiveType = PartyObjective.Party)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        var _postalAddress = Mapper.Map<PostalAddress>(request);
                        switch (objectiveType)
                        {
                            case PartyObjective.Person:
                                _postalAddress.PersonRefRecId = request.ParentId;
                                break;

                            case PartyObjective.Importer:
                                _postalAddress.ImporterRefRecId = request.ParentId;
                                break;

                            case PartyObjective.Organization:
                                _postalAddress.OrganizationRefRecId = request.ParentId;
                                break;

                            default:
                                _postalAddress.PartyRefRecId = request.ParentId;
                                break;
                        }
                        _postalAddressRpository.Add(_postalAddress);
                        switch (request.ObjectiveType)
                        {
                            case PartyObjective.Party:
                                return RedirectToAction(MVC.Party.PostalAddressList(request.ParentId));

                            case PartyObjective.Person:
                                return RedirectToAction(MVC.Person.PostalAddressList(request.ParentId));

                            case PartyObjective.Importer:
                                return RedirectToAction(MVC.Importer.PostalAddressList(request.ParentId));

                            case PartyObjective.Organization:
                                return RedirectToAction(MVC.Organization.PostalAddressList(request.ParentId));
                        }
                        //return RedirectToAction(MVC.Party.PostalAddressList(request.ParentId));
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
            request.ProvinceCityList = Common.sessionManager.getProvinceCities();
            return View(request);
        }

        [HttpGet]
        public virtual ActionResult ModifyPostalAddress(long parentId, long communicationId, PartyObjective objectiveType = PartyObjective.Party)
        {
            Party _party = null;
            string title = string.Empty;
            switch (objectiveType)
            {
                case PartyObjective.Person:
                    var _person = _personRepository.FindById(parentId, y => y.Party);
                    _party = _person.Party;
                    title = _person.FullName;
                    break;

                case PartyObjective.Importer:
                    var _importer = _importerRepository.FindById(parentId, y => y.Party);
                    _party = _importer.Party;
                    title = _importer.FullName;
                    break;

                case PartyObjective.Organization:
                    _party = _organizationRepository.FindById(parentId, y => y.Party).Party;
                    break;

                default:
                    _party = _partyRepository.FindById(parentId);
                    title = _party.Title;
                    break;
            }

            PostalAddress _model = _postalAddressRpository.FindById(communicationId, _ => _.Province, _ => _.City);
            if (_model == null)
            {
                return HttpNotFound();
            }
            var data = Mapper.Map<ViewModelCreateModifyPostalAddress>(_model);
            data.ParentId = parentId;
            data.PersonalTitle = _party.PersonalTitle;
            data.Title = title;
            data.NationalCode = _party.NationalCode;
            data.ProvinceCityList = Common.sessionManager.getProvinceCities();
            data.ObjectiveType = objectiveType;
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
                        switch (request.ObjectiveType)
                        {
                            case PartyObjective.Party:
                                return RedirectToAction(MVC.Party.PostalAddressList(request.ParentId));

                            case PartyObjective.Person:
                                return RedirectToAction(MVC.Person.PostalAddressList(request.ParentId));

                            case PartyObjective.Importer:
                                return RedirectToAction(MVC.Importer.PostalAddressList(request.ParentId));

                            case PartyObjective.Organization:
                                return RedirectToAction(MVC.Organization.PostalAddressList(request.ParentId));
                        }
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

        public virtual ActionResult ChangePrimary(long id, long parentId, bool status)
        {
            _postalAddressRpository.changePrimary(id, status);
            return Redirect(Request.UrlReferrer.ToString());
        }

        public virtual ActionResult PostalAddressDetail(List<ViewModelPostalAddress> request)
        {
            request = request ?? new List<ViewModelPostalAddress>();
            request = request.Select(_ =>
            {
                Tuple<string, string> tuple = Common.getProvinceAndCityTitleById(_.ProvinceCity);
                _.Province = tuple.Item1;
                _.City = tuple.Item2;
                return _;
            }).ToList();
            request.Add(new ViewModelPostalAddress()
            {
                ProvinceCityList = Common.sessionManager.getProvinceCities()
            });
            return PartialView(MVC.PostalAddress.Views._Repeater, request);
        }
    }
}