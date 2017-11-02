using AutoMapper;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Dashboard;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Notification;
using ir.ankasoft.entities.Repositories;
using ir.ankasoft.infrastructure;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers
{
    [Authorize]
    public partial class DashboardController : BaseController
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
            var model = new ViewModelDashboard
            {
                LatestActivities = Mapper.Map<List<ViewModelDisplayNotification>>(_notificationRepository.GetLatestActivities())
            };

            return View(model);
        }

        public virtual ActionResult DateTime()
        {
            return PartialView(MVC.Dashboard.Views._DateTime);
        }

        public virtual ActionResult ClearCache(string returnUrl = "")
        {
            if (Session != null)
                Session.Abandon();
            if (String.IsNullOrEmpty(returnUrl))
                return RedirectToAction(MVC.Dashboard.Index());
            //prevent open redirection attack
            //if (!Url.IsLocalUrl(returnUrl))
            //    return RedirectToAction("Index", "Home", new { area = "Admin" });
            return Redirect(returnUrl);
        }
    }
}