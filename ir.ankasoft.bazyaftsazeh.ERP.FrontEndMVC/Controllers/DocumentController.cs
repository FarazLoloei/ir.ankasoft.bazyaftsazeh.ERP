using AutoMapper;
using ir.ankasoft.bazyaftsazeh.ERP.entities;
using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Dashboard;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Document;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentCost;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentImperfection;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentPayment;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentStatus;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Vehicle;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.VehiclePlate;
using ir.ankasoft.entities.Repositories;
using ir.ankasoft.infrastructure;

using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IContextMenuItemRepository _contextMenuItemRepository;
        private readonly IReplacementPlanRepository _replacementPlanRepository;
        private readonly IGovernmentPlanRepository _governmentPlanRepository;
        private readonly IOperationsAttributeRepository _operationsAttributeRepository;
        private readonly IOperationsAttributeValueRepository _operationsAttributeValueRepository;
        private IMapper Mapper;

        public DocumentController(IPartyRepository partyRepository,
                                  IContextMenuItemRepository contextMenuItemRepository,
                                  IDocumentRepository documentRepository,
                                  IVehicleRepository vehicleRepository,
                                  IImporterRepository importerRepository,
                                  IOrganizationRepository organizationRepository,
                                  IPersonRepository personRepository,
                                  IUnitOfWorkFactory unitOfWorkFactory,
                                  IReplacementPlanRepository replacementPlanRepository,
                                  IGovernmentPlanRepository governmentPlanRepository,
                                  IOperationsAttributeRepository operationsAttributeRepository,
                                  IOperationsAttributeValueRepository operationsAttributeValueRepository)
        {
            _partyRepository = partyRepository;
            _importerRepository = importerRepository;
            _organizationRepository = organizationRepository;
            _personRepository = personRepository;
            _documentRepository = documentRepository;
            _vehicleRepository = vehicleRepository;
            _replacementPlanRepository = replacementPlanRepository;
            _governmentPlanRepository = governmentPlanRepository;
            _contextMenuItemRepository = contextMenuItemRepository;
            _operationsAttributeRepository = operationsAttributeRepository;
            _operationsAttributeValueRepository = operationsAttributeValueRepository;
            _unitOfWorkFactory = unitOfWorkFactory;

            Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
        }

        // GET: Document
        public virtual ActionResult Index(FilterDataSource request)
        {
            Common.sessionManager.getDashboardOperations();
            Common.sessionManager.getContextMenu(nameof(DocumentController).Replace(nameof(Controller), string.Empty));

            request.sort = new KeyValuePair<string, tools.SortType>(request.sortBy, (tools.SortType)request.sortType);
            if (Request.IsAjaxRequest())
                return PartialView(MVC.Document.Views._List,
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
                    int statusLevelId = 4;
                    var attributes = _operationsAttributeRepository.GetOperationsAttribute(statusLevelId);
                    using (_unitOfWorkFactory.Create())
                    {
                        var _document = Mapper.Map<Document>(request);
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
                        _document.GovernmentPlan = null;
                        _document.ReplacementPlan = null;
                        if (request.GovernmentPlan.PermissionNumber != null)
                            _document.GovernmentPlan = Mapper.Map<GovernmentPlan>(request.GovernmentPlan);
                        if (request.ReplacementPlan.BeneficiaryImporterRecId != 0)
                            _document.ReplacementPlan = Mapper.Map<ReplacementPlan>(request.ReplacementPlan);
                        _document.Vehicle = Mapper.Map<Vehicle>(request.Vehicle);
                        _document.Vehicle.Plate = Mapper.Map<Plate>(request.Vehicle.Plate);

                        //Insert New Status to Document
                        _document.DocumentStatusCollection.Add(new DocumentStatus()
                        {
                            Description = string.Empty,
                            DocumentOperationRefRecId = 3
                        });

                        //var nextStepDocumentStatus = new DocumentStatus()
                        //{
                        //    Description = string.Empty,
                        //    DocumentOperationRefRecId = statusLevelId,
                        //    AttributeValuesCollection = new List<OperationsAttributeValue>()
                        //};

                        //foreach (var item in attributes)
                        //{
                        //    nextStepDocumentStatus.AttributeValuesCollection.Add(new OperationsAttributeValue()
                        //    {
                        //        OperationsAttributeRefRecId = item.recId,
                        //        Value = item.DataType == entities.Enums.DataType.Boolean ? false.ToString() : " ",
                        //        DocumentStatusRefRecId = statusLevelId
                        //    });
                        //}
                        _document.DocumentStatusCollection.Add(getStepAttributes(4));//(nextStepDocumentStatus);
                        //_document.DocumentStatusCollection = _document.DocumentStatusCollection.Reverse().ToList();
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
            request.Vehicle = Mapper.Map<ViewModelCreateAndModifyVehicle>(request.Vehicle);
            request.LastOwner = request.PlateOwner = request.Investor = request.Contractor = CreatePartiesList();
            request.Vehicle.VehicleTip = Common.sessionManager.getVehicleTips();
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
                            y => y.Vehicle.Plate,
                            y => y.GovernmentPlan,
                            y => y.ReplacementPlan);
                        switch (_document.PlanType)
                        {
                            case entities.Enums.PlanType.Replacements:
                                _document.ReplacementPlan = _replacementPlanRepository.FindById(_document.ReplacementRefRecId ?? 0);
                                _document.GovernmentPlan = null;
                                break;

                            case entities.Enums.PlanType.Government:
                                _document.GovernmentPlan = _governmentPlanRepository.FindById(_document.GovernmentPlanRefRecId ?? 0);
                                _document.ReplacementPlan = null;
                                break;
                        }
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
                catch
                {
                }
            }
            request.Vehicle = Mapper.Map<ViewModelCreateAndModifyVehicle>(request.Vehicle);
            request.LastOwner = request.PlateOwner = request.Investor = request.Contractor = CreatePartiesList();
            request.Vehicle.VehicleTip = Common.sessionManager.getVehicleTips();
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

        [HttpGet]
        public virtual ActionResult ImperfectionList(long id)
        {
            Document _document = _documentRepository.FindById(id, x => x.ImperfectionCollection.Select(_ => _.Title));
            if (_document == null)
            {
                throw new Exception("ObjectNotFound");
            }
            ViewModelDocumentImperfection model = Mapper.Map<ViewModelDocumentImperfection>(_document);
            model.ImperfectionCollection = model.ImperfectionCollection.Select(_ => { _.ParentId = id; return _; }).ToList();
            return View(model);
        }

        [HttpGet]
        public virtual ActionResult PaymentsList(long id)
        {
            Document _document = _documentRepository.FindById(id, x => x.PaymentsCollection);
            if (_document == null)
            {
                throw new Exception("ObjectNotFound");
            }
            ViewModelDocumentPayment model = Mapper.Map<ViewModelDocumentPayment>(_document);
            model.PaymentsCollection = model.PaymentsCollection.Select(_ => { _.DocumentRecId = id; return _; }).ToList();
            return View(model);
        }

        [HttpGet]
        public virtual ActionResult Dashboard(long id, long statuscode)
        {
            var document = _documentRepository.FindById(id, x => x.DocumentStatusCollection,
                                                            x => x.DocumentStatusCollection.Select(_ => _.Operation.AttributeCollection));
            if (document == null) return RedirectToAction(MVC.Document.Index());
            var model = new ViewModelDocumentStatus();
            model.AttributesList =
                Mapper.Map<List<OperationsAttributeValue>,
                           List<ViewModelOperationsAttribute>>
                           (document.DocumentStatusCollection
                                .OrderBy(x => x.DocumentOperationRefRecId)
                                .Last().AttributeValuesCollection
                                .ToList());

            var attributes = _operationsAttributeRepository.GetOperationsAttribute(statuscode);

            model.AttributesList = (from item in model.AttributesList
                                    join attribute in attributes on item.OperationsAttributeTitleRefRecId equals attribute.recId
                                    select new ViewModelOperationsAttribute()
                                    {
                                        recId = item.recId,
                                        DataType = attribute.DataType,
                                        OperationsAttributeTitleRefRecId = item.OperationsAttributeTitleRefRecId,
                                        OperationsAttributeTitle = attribute.Title,
                                        Value = item.Value,
                                        StatusRecId = item.StatusRecId
                                    }).OrderBy(x => x.DataType).ToList();

            model.Document.recId = id;
            model.StatusRecId = statuscode;
            model.Description = document.DocumentStatusCollection.Where(x => x.DocumentOperationRefRecId == statuscode).First().Description;

            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Dashboard(ViewModelDocumentStatus request, List<HttpPostedFileBase> Files)
        {
            List<ResourceRepo> resourcesList = new List<ResourceRepo>();
            try
            {
                using (_unitOfWorkFactory.Create())
                {
                    var document = _documentRepository.FindById(request.Document.recId, x => x.DocumentStatusCollection.Select(y => y.AttributeValuesCollection.Select(z => z.OperationsAttribute)));
                    document.GovernmentPlan = null;
                    document.ReplacementPlan = null;

                    if (Files != null)
                        foreach (var item in Files)
                        {
                            if (item.ContentLength > 0)
                            {
                                FileInfo fileInfo = new FileInfo(item.FileName);
                                var resource = new ResourceRepo()
                                {
                                    FileOriginalTitle = fileInfo.Name,

                                    DocumentStatusRefRecId = request.StatusRecId

                                };

                                resourcesList.Add(resource);
                                var path = $"{Server.MapPath(tools.DefaultValues.ResourceRelativePath)}\\{resource.TitleGUID}{fileInfo.Extension}";
                                item.SaveAs(path);
                                request.AttributesList[0].Value = "valid";
                            }
                        }

                    DocumentStatus oldDocumentStatus = document.DocumentStatusCollection.Where(x => x.DocumentOperationRefRecId == request.StatusRecId).Last();
                    oldDocumentStatus.ResourceRepoCollection = resourcesList;
                    foreach (var item in oldDocumentStatus.AttributeValuesCollection)
                    {
                        item.Value = request.AttributesList.Where(x => x.recId == item.recId).First().Value;
                    }
                    oldDocumentStatus.Description = request.Description;

                    if (oldDocumentStatus.AttributeValuesCollection.Where(x => !x.valueCouldPassValidation()).Count() == 0)
                    {
                        document.DocumentStatusCollection.Add(getStepAttributes(request.StatusRecId + 1));
                    }
                }
                return RedirectToAction(MVC.Document.Index());
            }
            catch (ModelValidationException modelValidationException)
            {
                foreach (var error in modelValidationException.ValidationErrors)
                {
                    ModelState.AddModelError(error.MemberNames.FirstOrDefault() ?? string.Empty, error.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                foreach (var item in resourcesList)
                {
                    FileInfo fileInfo = new FileInfo(item.FileOriginalTitle);
                    System.IO.File.Delete($"{ Server.MapPath(tools.DefaultValues.ResourceRelativePath)}\\{item.TitleGUID}{fileInfo.Extension}");
                }
            }
            return RedirectToAction(MVC.Document.Dashboard(request.Document.recId, request.StatusRecId));
            //return View(request, new { id = request.Document.recId , statuscode = request.StatusRecId });
        }

        private DocumentStatus getStepAttributes(long statusId)
        {
            var attributes = _operationsAttributeRepository.GetOperationsAttribute(statusId);

            var nextStepDocumentStatus = new DocumentStatus()
            {
                Description = string.Empty,
                DocumentOperationRefRecId = statusId,
                AttributeValuesCollection = new List<OperationsAttributeValue>()
            };

            foreach (var item in attributes)
            {
                nextStepDocumentStatus.AttributeValuesCollection.Add(new OperationsAttributeValue()
                {
                    OperationsAttributeRefRecId = item.recId,
                    Value = item.DataType == entities.Enums.DataType.Boolean ? false.ToString() : " ",
                    DocumentStatusRefRecId = statusId
                });
            }

            return nextStepDocumentStatus;
        }
    }
}