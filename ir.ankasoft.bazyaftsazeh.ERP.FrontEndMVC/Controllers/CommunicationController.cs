using AutoMapper;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Communication;
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
    public partial class CommunicationController : Controller
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly ICommunicationRepository _communicationRpository;
        private readonly IPartyRepository _partyRepository;
        private readonly IPersonRepository _personRepository;

        private IMapper Mapper;

        public CommunicationController(ICommunicationRepository communicationRpository,
                                       IPartyRepository partyRepository,
                                       IPersonRepository personRepository,
                                       IUnitOfWorkFactory unitOfWorkFactory)
        {
            _communicationRpository = communicationRpository;
            _partyRepository = partyRepository;
            _personRepository = personRepository;
            _unitOfWorkFactory = unitOfWorkFactory;

            Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
        }
        // GET: Communication
        public virtual ActionResult Index()
        {
            throw new NotImplementedException();
            //return View();
        }

        [HttpGet]
        public virtual ActionResult CreateCommunication(long parentId, PartyObjective partyObjective)
        {
            Party _party = null;
            string title = string.Empty;
            switch (partyObjective)
            {
                
                case PartyObjective.Person:
                    var _person = _personRepository.FindById(parentId, y => y.Party);
                    title = _person.FullName;
                    _party = _person.Party;
                    break;
                case PartyObjective.Importer:
                    break;
                case PartyObjective.Organization:
                    break;
                default:
                    _party = _partyRepository.FindById(parentId);
                    title = _party.Title;
                    break;
            }
            var model = new ViewModelCreateModifyCommunication()
            {

                ParentId = parentId,
                PersonalTitle = _party.PersonalTitle,
                Title = title,
                NationalCode = _party.NationalCode,
                ObjectiveType = partyObjective
            };
            return View(model);
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
                        switch (request.ObjectiveType)
                        {
                            case PartyObjective.Party:
                                _communication.PartyRefRecId = request.ParentId;
                                break;
                            case PartyObjective.Person:
                                _communication.PersonRefRecId = request.ParentId;
                                break;
                            case PartyObjective.Importer:
                                _communication.ImporterRefRecId = request.ParentId;
                                break;
                            case PartyObjective.Organization:
                                _communication.OrganizationRefRecId = request.ParentId;
                                break;
                        }
                        _communicationRpository.Add(_communication); switch (request.ObjectiveType)
                        {
                            case PartyObjective.Party:
                                return RedirectToAction(MVC.Party.CommunicationList(request.ParentId));
                            case PartyObjective.Person:
                                return RedirectToAction(MVC.Person.CommunicationList(request.ParentId));
                            case PartyObjective.Importer:
                                //_communication.ImporterRefRecId = request.ParentId;
                                break;
                            case PartyObjective.Organization:
                                //_communication.OrganizationRefRecId = request.ParentId;
                                break;
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

        [HttpGet]
        public virtual ActionResult ModifyCommunication(long parentId, long communicationId, PartyObjective objectiveType = PartyObjective.Party)
        {
            Party _party = new Party();
            switch (objectiveType)
            {
                case PartyObjective.Person:
                    _party = _personRepository.FindById(parentId, y => y.Party).Party;
                    break;
                case PartyObjective.Importer:
                    break;
                case PartyObjective.Organization:
                    break;
                default:
                    _party = _partyRepository.FindById(parentId);
                    break;
            }
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
            data.ObjectiveType = objectiveType;
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
                        switch (request.ObjectiveType)
                        {
                            case PartyObjective.Party:
                                return RedirectToAction(MVC.Party.CommunicationList(request.ParentId));
                            case PartyObjective.Person:
                                return RedirectToAction(MVC.Person.CommunicationList(request.ParentId));
                            case PartyObjective.Importer:
                                break;
                            case PartyObjective.Organization:
                                break;
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
            _communicationRpository.changePrimary(id, ankasoft.entities.Enums.PartyObjective.Party, status);
            return Redirect(Request.UrlReferrer.ToString());
        }

        public virtual ActionResult RemoveCommunication(long id, long parentId)
        {
            _communicationRpository.Remove(id);
            return RedirectToAction(MVC.Party.CommunicationList(parentId));
        }

        public virtual ActionResult CommunicationDetail(List<ViewModelCommunication> request)
        {
            request = request ?? new List<ViewModelCommunication>();
            request.Add(new ViewModelCommunication());
            return PartialView(MVC.Communication.Views._Repeater, request);
        }
    }
}