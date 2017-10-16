using AutoMapper;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Party;
using ir.ankasoft.entities;
using ir.ankasoft.entities.Repositories;
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
        private readonly IContextMenuItemRepository _contextMenuItemRepository;
        private IMapper Mapper;

        public PartyController(IPartyRepository partyRepository,
                               IContextMenuItemRepository contextMenuItemRepository,
                               IUnitOfWorkFactory unitOfWorkFactory)
        {
            _partyRepository = partyRepository;
            _contextMenuItemRepository = contextMenuItemRepository;
            _unitOfWorkFactory = unitOfWorkFactory;


            Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
        }

        // GET: Party
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

        private PagerModel<PartyDisplayViewModel> Load(FilterDataSource request)
        {
            var data = new List<PartyDisplayViewModel>();
            int totalRecords;
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
            };
            return model;
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            return View(new ViewModelCreateAndEditCounterParty() );
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(ViewModelCreateAndEditCounterParty request)
        {
            return View();
        }
    }
}