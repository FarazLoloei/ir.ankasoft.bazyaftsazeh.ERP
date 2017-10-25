using AutoMapper;
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
        private IMapper Mapper;

        public CommunicationController(ICommunicationRepository communicationRpository,
                                       IUnitOfWorkFactory unitOfWorkFactory)
        {
            _communicationRpository = communicationRpository;
            _unitOfWorkFactory = unitOfWorkFactory;

            Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
        }
        // GET: Communication
        public virtual ActionResult Index()
        {
            throw new NotImplementedException();
            //return View();
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
    }
}