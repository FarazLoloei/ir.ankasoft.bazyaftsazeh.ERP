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
        
        private IMapper Mapper;

        public CommunicationController(ICommunicationRepository communicationRpository,
                                       IPartyRepository partyRepository,
                                       IUnitOfWorkFactory unitOfWorkFactory)
        {
            _communicationRpository = communicationRpository;
            _partyRepository = partyRepository;
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
        public virtual ActionResult CreateCommunication(long parentId, PartyObjective type)
        {
            return View(new ViewModelCreateModifyCommunication() { ParentId = parentId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult CreateCommunication(ViewModelCreateModifyCommunication request, PartyObjective type)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        var _communication = Mapper.Map<Communication>(request);
                        switch (type)
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

        public virtual ActionResult ChangePrimary(long id, long parentId, bool status)
        {
            _communicationRpository.changePrimary(id, ankasoft.entities.Enums.PartyObjective.Party, status);
            return RedirectToAction("CommunicationList", "Party", new { id = parentId });
            //return RedirectToAction(MVC.Party.CommunicationList(parentId));
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