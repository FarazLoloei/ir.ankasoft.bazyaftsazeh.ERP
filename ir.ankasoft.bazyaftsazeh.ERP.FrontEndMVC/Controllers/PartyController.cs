using AutoMapper;
using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Party;
using ir.ankasoft.entities;
using ir.ankasoft.infrastructure;
using ir.ankasoft.tools;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public virtual ActionResult Index(int? currentPage,
                                  string keyword = DefaultValues.EmptyString,
                                  int pageSize = DefaultValues.PageSize,
                                  string sort = "recId",
                                  string sortDir = "ASC")
        {
            int _currentPage = currentPage ?? 1;
            //if (Request.IsAjaxRequest())
            //    return PartialView(MVC.Category.Views._List,
            //                       Load(keyword,
            //                            _currentPage,
            //                            pageSize,
            //                            sort,
            //                            sortDir));
            return View(Load(keyword,
                             _currentPage,
                             pageSize,
                             sort,
                             sortDir));
        }

        private PagerModel<PartyDisplayViewModel> Load(string keyword,
                                                          int currentPage,
                                                          int pageSize,
                                                          string sort,
                                                          string sortDir)
        {
            var data = new List<PartyDisplayViewModel>();
            int totalRecords;
            IQueryable<Party> parties =
                _partyRepository.LoadByFilter(
                    keyword,
                    currentPage,
                    pageSize,
                    sort,
                    sortDir,
                    out totalRecords)
                                   .AsQueryable();

            data = Mapper.Map<List<PartyDisplayViewModel>>(parties);
            var model = new PagerModel<PartyDisplayViewModel>
            {
                Data = data,
                PageData = new PagerData
                {
                    CurrentPage = currentPage,
                    PageSize = pageSize,
                    TotalRows = totalRecords,
                    PageCount = Paging.ComputePageCount(totalRecords)
                }
            };
            return model;
        }
    }
}