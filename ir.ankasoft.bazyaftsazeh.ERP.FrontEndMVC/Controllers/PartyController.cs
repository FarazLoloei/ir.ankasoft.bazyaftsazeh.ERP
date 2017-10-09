using AutoMapper;
using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Party;
using ir.ankasoft.entities;
using ir.ankasoft.infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers
{
    public partial class PartyController : BaseController
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IPartyRepository _partyRepository;
        private IMapper Mapper;

        public PartyController(IPartyRepository partyRepository,
                               IUnitOfWorkFactory unitOfWorkFactory)
        {
            _partyRepository = partyRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
            Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
        }

        // GET: Party
        public virtual ActionResult Index(FilterDataSource request)
        {
            //int _currentPage = currentPage ?? 1;
            if (Request.IsAjaxRequest())
                return PartialView(MVC.Party.Views._List,
                                   Load(request));
            return View(Load(request));
        }

        private PagerModel<PartyDisplayViewModel> Load(FilterDataSource request)
        {
            //if (request.Filter == null) request.Filter = new PartyDisplayViewModel();

            var data = new List<PartyDisplayViewModel>();
            int totalRecords;
            //infrastructure.IFilterDataSource s =
            IQueryable<Party> parties =
                _partyRepository.LoadByFilter(
                    request, out totalRecords)
                                   .AsQueryable();

            data = Mapper.Map<List<PartyDisplayViewModel>>(parties);

            var model = new PagerModel<PartyDisplayViewModel>
            {
                Data = data,
                PageData = new PagerData
                {
                    filterDataSource = request,
                    TotalRows = totalRecords,
                },

                //Filter = request.
            };
            return model;
        }
    }
}