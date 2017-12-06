using AutoMapper;
using ir.ankasoft.bazyaftsazeh.ERP.entities;
using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Document;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentCost;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentImperfection;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Vehicle;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.VehiclePlate;
using ir.ankasoft.entities.Repositories;
using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IContextMenuItemRepository _contextMenuItemRepository;
        private IMapper Mapper;

        public DocumentController(IPartyRepository partyRepository,
                                  IContextMenuItemRepository contextMenuItemRepository,
                                  IDocumentRepository documentRepository,
                                  IVehicleRepository vehicleRepository,
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
            _vehicleRepository = vehicleRepository;
            //_plateRepository = plateRepository;
            _contextMenuItemRepository = contextMenuItemRepository;
            _unitOfWorkFactory = unitOfWorkFactory;

            Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
        }

        // GET: Document
        public virtual ActionResult Index(FilterDataSource request)
        {
            Common.sessionManager.getContextMenu(nameof(DocumentController).Replace(nameof(Controller), string.Empty));

            request.sort = new KeyValuePair<string, tools.SortType>(request.sortBy, (tools.SortType)request.sortType);
            if (Request.IsAjaxRequest())
                return PartialView(MVC.Party.Views._List,
                                   Load(request));
            return View(Load(request));
        }

        private PagerModel<ViewModelDisplayDocument> Load(FilterDataSource request)
        {
            var data = new List<ViewModelDisplayDocument>();
            int totalRecords;
            IQueryable<Document> documents =
                _documentRepository.LoadByFilter(
                    request, out totalRecords)
                                   .AsQueryable();
            data = Mapper.Map<List<ViewModelDisplayDocument>>(documents);
            var model = new PagerModel<ViewModelDisplayDocument>
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
            var model = new ViewModelCreateDocument();
            model.LastOwner = model.PlateOwner = model.Investor = model.Contractor = CreatePartiesList();
            model.ReplacementPlan.BeneficiaryImporter = CreateImportersList();
            model.GovernmentPlan.Organization = CreateOrganizationlist();
            model.ReplacementPlan.Representor = CreatePeopleList();
            model.Vehicle.VehicleTip = Common.sessionManager.getVehicleTips();
            return View(model);
        }

        private List<SelectListItem> CreatePeopleList()
        {
            var _personList = _personRepository.GetForSelectors(string.Empty).Select(_ => new SelectListItem()
            {
                Text = _.Value,
                Value = _.Key.ToString()
            }).ToList();
            _personList.Insert(0, new SelectListItem() { Text = resource.Resource.SelectAValue, Value = "0" });
            return _personList;
        }

        private List<SelectListItem> CreateOrganizationlist()
        {
            var _organizationList = _organizationRepository.GetForSelectors(string.Empty).Select(_ => new SelectListItem()
            {
                Text = _.Value,
                Value = _.Key.ToString()
            }).ToList();
            _organizationList.Insert(0, new SelectListItem() { Text = resource.Resource.SelectAValue, Value = "0" });
            return _organizationList;
        }

        private List<SelectListItem> CreateImportersList()
        {
            var _importersList = _importerRepository.GetForSelectors(string.Empty).Select(_ => new SelectListItem()
            {
                Text = _.Value,
                Value = _.Key.ToString()
            }).ToList();
            _importersList.Insert(0, new SelectListItem() { Text = resource.Resource.SelectAValue, Value = "0" });
            return _importersList;
        }

        private List<SelectListItem> CreatePartiesList()
        {
            var _partiesList = _partyRepository.GetForSelectors(string.Empty).Select(_ => new SelectListItem()
            {
                Text = _.Value,
                Value = _.Key.ToString()
            }).ToList();
            _partiesList.Insert(0, new SelectListItem() { Text = resource.Resource.SelectAValue, Value = "0" });
            return _partiesList;
        }

        [HttpPost]
        public virtual ActionResult Create(ViewModelCreateDocument request,
            List<ViewModelCreateAndModifyDocumentCost> documentCostCollection,
            List<ViewModelCreateAndModifyDocumentImperfection> documentImperfectionCollection)
        {
            if (documentCostCollection != null)
                request.CostCollection = documentCostCollection.Where(_ => !string.IsNullOrEmpty(_.CostTitle)).ToList();
            if (documentImperfectionCollection != null)
            {
                request.ImperfectionCollection = documentImperfectionCollection.Where(_ => !string.IsNullOrEmpty(_.ImperfectionTitle)).ToList();
                request.ImperfectionCollection = request.ImperfectionCollection.Count() > 0 ? request.ImperfectionCollection : null;
            }
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        var _document = Mapper.Map<Document>(request);
                        //_document.Costs = Mapper.Map<List<DocumentCost>, List<ViewModelCreateAndModifyDocumentCost>>(request.CostCollection);
                        if (request.CostCollection != null)
                            _document.CostCollection = request.CostCollection.Select(_ =>
                            {
                                return new DocumentCost()
                                {
                                    PreDefineTitleRefRecId = Convert.ToInt32(_.CostTitle.Split(',')[0]),
                                    Value = _.CostValue
                                };
                            }).ToList();

                        if (request.ImperfectionCollection != null)
                            _document.ImperfectionCollection = request.ImperfectionCollection.Select(_ =>
                            {
                                return new DocumentImperfection()
                                {
                                    PreDefineTitleRefRecId = Convert.ToInt32(_.ImperfectionTitle.Split(',')[0]),
                                    Value = _.ImperfectionValue
                                };
                            }).ToList();

                        _document.Vehicle = Mapper.Map<Vehicle>(request.Vehicle);
                        _document.Vehicle.Plate = Mapper.Map<Plate>(request.Vehicle.Plate);
                        _documentRepository.Add(_document);
                        return RedirectToAction(MVC.Document.Index());
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
        public virtual ActionResult Modify(long id)
        {
            var _model = _documentRepository.FindById(id, y => y.Contractor,
                                                          y => y.Investor,
                                                          y => y.LastOwner,
                                                          y => y.PlateOwner,
                                                          y => y.Vehicle,
                                                          y => y.Vehicle.Plate,
                                                          y => y.Vehicle.VehicleTip);
            if (_model == null)
                return HttpNotFound();
            var data = Mapper.Map<ViewModelModifyDocument>(_model);
            data.Vehicle = Mapper.Map<ViewModelCreateAndModifyVehicle>(_model.Vehicle);
            data.LastOwner = data.PlateOwner = data.Investor = data.Contractor = CreatePartiesList();
            data.Vehicle.VehicleTip = Common.sessionManager.getVehicleTips();
            return View(data);
        }

        [HttpPost]
        public virtual ActionResult Modify(ViewModelModifyDocument request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        Document _document = _documentRepository.FindById(request.recId,
                            y => y.Vehicle,
                            y => y.Vehicle.Plate);
                        Mapper.Map(request, _document, typeof(ViewModelModifyDocument), typeof(Document));
                        Mapper.Map(request.Vehicle.Plate, _document.Vehicle.Plate,
                            typeof(ViewModelCreateAndModifyVehiclePlate),
                            typeof(Plate));
                        return RedirectToAction(MVC.Document.Index());
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

        public virtual ActionResult Remove(int id)
        {
            return View();
        }

        [HttpGet]
        public virtual ActionResult CostList(long id)
        {
            Document _document = _documentRepository.FindById(id, x => x.CostCollection.Select(_ => _.Title));
            if (_document == null)
            {
                throw new Exception("ObjectNotFound");
            }
            ViewModelDocumentCost model = Mapper.Map<ViewModelDocumentCost>(_document);
            model.CostCollection = model.CostCollection.Select(_ => { _.ParentId = id; return _; }).ToList();
            return View(model);
        }
    }
}