using AutoMapper;
using ir.ankasoft.bazyaftsazeh.ERP.entities;
using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Document;
using ir.ankasoft.entities.Repositories;
using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers
{
    public partial class DocumentController : BaseController
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IPartyRepository _partyRepository;
        private readonly IImporterRepository _importerRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IDocumentRepository _documentRepository;

        private readonly IContextMenuItemRepository _contextMenuItemRepository;
        private IMapper Mapper;

        public DocumentController(IPartyRepository partyRepository,
                                  IContextMenuItemRepository contextMenuItemRepository,
                                  IDocumentRepository documentRepository,
                                  IImporterRepository importerRepository,
                                  IOrganizationRepository organizationRepository,
                                  IPersonRepository personRepository,
                                  IUnitOfWorkFactory unitOfWorkFactory)
        {
            _partyRepository = partyRepository;
            _importerRepository = importerRepository;
            _organizationRepository = organizationRepository;
            _personRepository = personRepository;
            _documentRepository = documentRepository;
            _contextMenuItemRepository = contextMenuItemRepository;
            _unitOfWorkFactory = unitOfWorkFactory;

            Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
        }
        // GET: Document
        public virtual ActionResult Index(FilterDataSource request)
        {
            Common.sessionManager.getContextMenu(nameof(PartyController).Replace(nameof(Controller), string.Empty));

            request.sort = new KeyValuePair<string, tools.SortType>(request.sortBy, (tools.SortType)request.sortType);
            if (Request.IsAjaxRequest())
                return PartialView(MVC.Party.Views._List,
                                   Load(request));
            return View(Load(request));
        }

        private PagerModel<ViewModelDocumentDisplay> Load(FilterDataSource request)
        {
            var data = new List<ViewModelDocumentDisplay>();
            int totalRecords;
            IQueryable<Document> documents =
                _documentRepository.LoadByFilter(
                    request, out totalRecords)
                                   .AsQueryable();
            data = Mapper.Map<List<ViewModelDocumentDisplay>>(documents);
            var model = new PagerModel<ViewModelDocumentDisplay>
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
            var _partiesList = _partyRepository.GetForSelectors(string.Empty).Select(_ => new SelectListItem()
            {
                Text = _.Value,
                Value = _.Key.ToString()
            }).ToList();
            _partiesList.Insert(0, new SelectListItem() { Text = resource.Resource.SelectAValue, Value = "0" });
            var _importersList = _importerRepository.GetForSelectors(string.Empty).Select(_ => new SelectListItem()
            {
                Text = _.Value,
                Value = _.Key.ToString()
            }).ToList();
            _importersList.Insert(0, new SelectListItem() { Text = resource.Resource.SelectAValue, Value = "0" });
            var _organizationList = _organizationRepository.GetForSelectors(string.Empty).Select(_ => new SelectListItem()
            {
                Text = _.Value,
                Value = _.Key.ToString()
            }).ToList();
            _organizationList.Insert(0, new SelectListItem() { Text = resource.Resource.SelectAValue, Value = "0" });
            var _personList = _personRepository.GetForSelectors(string.Empty).Select(_ => new SelectListItem()
            {
                Text = _.Value,
                Value = _.Key.ToString()
            }).ToList();
            _personList.Insert(0, new SelectListItem() { Text = resource.Resource.SelectAValue, Value = "0" });
            var model = new ViewModelCreateDocument();
            model.LastOwner = model.PlateOwner = model.Investor = model.Contractor = _partiesList;
            model.BeneficiaryImporter = _importersList;
            model.Organization = _organizationList;
            model.Representor = _personList;
            return View(model);
        }
    }
}