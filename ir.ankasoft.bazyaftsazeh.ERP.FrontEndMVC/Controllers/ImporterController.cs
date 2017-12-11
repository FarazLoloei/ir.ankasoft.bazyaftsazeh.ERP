using AutoMapper;
using ir.ankasoft.bazyaftsazeh.ERP.entities;
using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Communication;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Importer;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.PostalAddress;
using ir.ankasoft.entities.Repositories;
using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers
{
    [Authorize]
    public partial class ImporterController : BaseController
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IImporterRepository _importerRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ICommunicationRepository _communicationRpository;
        private readonly IPostalAddressRepository _postalAddressRpository;
        private readonly IContextMenuItemRepository _contextMenuItemRepository;
        private IMapper Mapper;

        public ImporterController(IPartyRepository partyRepository,
                                IImporterRepository importerRepository,
                                IContextMenuItemRepository contextMenuItemRepository,
                                ICityRepository cityRepository,
                                ICommunicationRepository communicationRpository,
                                IPostalAddressRepository postalAddressRpository,
                                IUnitOfWorkFactory unitOfWorkFactory)
        {
            _importerRepository = importerRepository;
            _contextMenuItemRepository = contextMenuItemRepository;
            _cityRepository = cityRepository;
            _communicationRpository = communicationRpository;
            _postalAddressRpository = postalAddressRpository;
            _unitOfWorkFactory = unitOfWorkFactory;

            Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
        }

        // GET: Importer
        public virtual ActionResult Index(FilterDataSource request)
        {
            Common.sessionManager.getContextMenu(nameof(ImporterController).Replace(nameof(Controller), string.Empty));

            request.sort = new KeyValuePair<string, tools.SortType>(request.sortBy, (tools.SortType)request.sortType);
            if (Request.IsAjaxRequest())
                return PartialView(MVC.Importer.Views._List,
                                   Load(request));
            return View(Load(request));
        }

        private PagerModel<ViewModelImporterDisplay> Load(FilterDataSource request)
        {
            var data = new List<ViewModelImporterDisplay>();
            int totalRecords;
            IQueryable<Importer> parties =
                _importerRepository.LoadByFilter(
                    request, out totalRecords)
                                   .AsQueryable();
            data = Mapper.Map<List<ViewModelImporterDisplay>>(parties);
            var model = new PagerModel<ViewModelImporterDisplay>
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
        public virtual ActionResult Create(long partyId = 0)
        {
            if (partyId == 0) return RedirectToAction(MVC.Importer.Index());
            var model = new ViewModelCreateImporter() { parentId = partyId };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(ViewModelCreateImporter request,
            List<ViewModelCommunication> communicationCollection,
            List<ViewModelPostalAddress> postalAddressCollection)
        {
            if (communicationCollection != null)
                request.CommunicationCollection = communicationCollection.Where(_ => !string.IsNullOrEmpty(_.Value)).ToList();
            if (postalAddressCollection != null)
            {
                request.PostalAddressCollection = postalAddressCollection.Where(_ => !string.IsNullOrEmpty(_.Postal_Value)).ToList();
                request.PostalAddressCollection = request.PostalAddressCollection.Count() > 0 ? request.PostalAddressCollection : null;
            }
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        var _importer = Mapper.Map<Importer>(request);
                        _importerRepository.Add(_importer);
                        return RedirectToAction(MVC.Importer.Index());
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

        public virtual ActionResult Modify(long id)
        {
            Importer _model = _importerRepository.FindById(id);
            if (_model == null)
            {
                return HttpNotFound();
            }
            var data = Mapper.Map<ViewModelModifyImporter>(_model);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Modify(ViewModelModifyImporter request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        Importer _importer = _importerRepository.FindById(request.recId);
                        Mapper.Map(request, _importer, typeof(ViewModelModifyImporter), typeof(Importer));
                        return RedirectToAction(MVC.Importer.Index());
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

        public virtual ActionResult Remove(long id)
        {
            using (_unitOfWorkFactory.Create())
            {
                _importerRepository.Remove(id);
            }
            return RedirectToAction(MVC.Importer.Index());
        }

        [HttpGet]
        public virtual ActionResult CommunicationList(long id)
        {
            Importer _importer = _importerRepository.FindById(id, y => y.Party);
            if (_importer == null)
            {
                throw new Exception("ObjectNotFound");
            }
            ViewModelImporterCommunication model = Mapper.Map<ViewModelImporterCommunication>(_importer);
            model.CommunicationCollection = model.CommunicationCollection.Select(_ => { _.ParentId = id; return _; }).ToList();
            model.NationalCode = _importer.Party.NationalCode;
            model.PersonalTitle = _importer.Party.PersonalTitle;
            model.Title = _importer.FullName;
            return View(model);
        }

        [HttpGet]
        public virtual ActionResult PostalAddressList(long id)
        {
            Importer _importer = _importerRepository.FindById(id, _ => _.PostalAddressCollection.Select(y => y.Province),
                _ => _.PostalAddressCollection.Select(y => y.City),
                y => y.Party);
            if (_importer == null)
            {
                throw new Exception("ObjectNotFound");
            }
            ViewModelImporterCommunication model = Mapper.Map<ViewModelImporterCommunication>(_importer);
            model.PostalAddressCollection = model.PostalAddressCollection.Select(_ => { _.Postal_ParentId = id; return _; }).ToList();
            model.CommunicationCollection = model.CommunicationCollection.Select(_ => { _.ParentId = id; return _; }).ToList();
            model.NationalCode = _importer.Party.NationalCode;
            model.PersonalTitle = _importer.Party.PersonalTitle;
            model.Title = _importer.FullName;
            return View(model);
        }
    }
}