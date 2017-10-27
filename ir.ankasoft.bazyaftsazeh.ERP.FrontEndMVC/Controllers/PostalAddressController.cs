using AutoMapper;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.PostalAddress;
using ir.ankasoft.entities;
using ir.ankasoft.entities.Enums;
using ir.ankasoft.entities.Repositories;
using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers
{
    public partial class PostalAddressController : Controller
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IPostalAddressRepository _postalAddressRpository;
        private readonly IPartyRepository _partyRepository;
        private readonly ICityRepository _cityRepository;
        private IMapper Mapper;

        public PostalAddressController(IPostalAddressRepository postalAddressRpository,
                                       IPartyRepository partyRepository,
                                       ICityRepository cityRepository,
                                       IUnitOfWorkFactory unitOfWorkFactory)
        {
            _postalAddressRpository = postalAddressRpository;
            _partyRepository = partyRepository;
            _cityRepository = cityRepository;
            _unitOfWorkFactory = unitOfWorkFactory;

            Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
        }

        // GET: PostalAddress
        public virtual ActionResult Index()
        {
            throw new NotImplementedException();
            //return View();
        }

        [HttpGet]
        public virtual ActionResult CreatePostalAddress(long parentId, PartyObjective type)
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
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult CreatePostalAddress(ViewModelCreateModifyPostalAddress request, PartyObjective type)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        var _postalAddress = Mapper.Map<PostalAddress>(request);
                        switch (type)
                        {
                            case PartyObjective.Party:
                                _postalAddress.PartyRefRecId = request.ParentId;
                                break;
                            case PartyObjective.Person:
                                _postalAddress.PersonRefRecId = request.ParentId;
                                break;
                            case PartyObjective.Importer:
                                _postalAddress.ImporterRefRecId = request.ParentId;
                                break;
                            case PartyObjective.Organization:
                                _postalAddress.OrganizationRefRecId = request.ParentId;
                                break;
                        }
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

        public virtual ActionResult ChangePrimary(long id, long parentId, bool status)
        {
            _postalAddressRpository.changePrimary(id, ankasoft.entities.Enums.PartyObjective.Party, status);
            return RedirectToAction("PostalAddressList", "Party", new { id = parentId });
            //return RedirectToAction(MVC.Party.CommunicationList(parentId));
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