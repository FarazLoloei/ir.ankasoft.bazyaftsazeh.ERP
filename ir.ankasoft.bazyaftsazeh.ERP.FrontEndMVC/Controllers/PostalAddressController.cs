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
    public partial class PostalAddressController : Controller
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IPostalAddressRepository _postalAddressRpository;
        private IMapper Mapper;

        public PostalAddressController(IPostalAddressRepository postalAddressRpository,
                                       IUnitOfWorkFactory unitOfWorkFactory)
        {
            _postalAddressRpository = postalAddressRpository;
            _unitOfWorkFactory = unitOfWorkFactory;

            Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
        }

        // GET: PostalAddress
        public virtual ActionResult Index()
        {
            throw new NotImplementedException();
            //return View();
        }

        public virtual ActionResult ChangePrimary(long id, long parentId, bool status)
        {
            _postalAddressRpository.changePrimary(id, ankasoft.entities.Enums.PartyObjective.Party, status);
            return RedirectToAction("PostalAddressList", "Party", new { id = parentId });
            //return RedirectToAction(MVC.Party.CommunicationList(parentId));
        }
    }
}