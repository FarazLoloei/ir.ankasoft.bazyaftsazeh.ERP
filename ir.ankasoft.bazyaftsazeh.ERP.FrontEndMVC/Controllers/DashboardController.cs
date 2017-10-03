﻿using AutoMapper;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Dashboard;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Notification;
using ir.ankasoft.entities.Repositories;
using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers
{
    [Authorize]
    public partial class DashboardController : Controller
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private IMapper Mapper;

        public DashboardController(INotificationRepository notificationRepository,
                                  IUnitOfWorkFactory unitOfWorkFactory)
        {
            _notificationRepository = notificationRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
            Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
        }
        // GET: Dashboard
        public virtual ActionResult Index()
        {
            var model = new ViewModelDashboard();
            //{
            //    LatestActivities = Mapper.Map<List<ViewModelDisplayNotification>>(_notificationRepository.GetLatestActivities())
            //};

            return View(model);
        }

        public virtual ActionResult DateTime()
        {
            return PartialView(MVC.Dashboard.Views._DateTime);
        }
    }
}