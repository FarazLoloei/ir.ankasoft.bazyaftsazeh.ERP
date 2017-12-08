using AutoMapper;
using ir.ankasoft.bazyaftsazeh.ERP.entities;
using ir.ankasoft.bazyaftsazeh.ERP.entities.Repositories;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentPayment;
using ir.ankasoft.infrastructure;
using System.Linq;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Controllers
{
    public partial class DocumentPaymentController : Controller
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IPaymentRepository _paymentRepository;
        private IMapper Mapper;

        public DocumentPaymentController(IPaymentRepository paymentRpository,
                                         IUnitOfWorkFactory unitOfWorkFactory)
        {
            _paymentRepository = paymentRpository;
            _unitOfWorkFactory = unitOfWorkFactory;

            Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
        }

        [HttpGet]
        public virtual ActionResult Create(long parentId)
        {
            var model = new ViewModelCreateAndModifyDocumentPayment()
            {
                DocumentRecId = parentId,
                TransactionDateShamsi = tools.Utility.PersianDateTime.Today,
                DueDateShamsi = tools.Utility.PersianDateTime.Today
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(ViewModelCreateAndModifyDocumentPayment request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        var _payment = Mapper.Map<Payment>(request);

                        _paymentRepository.Add(_payment);
                        return RedirectToAction(MVC.Document.PaymentsList(request.DocumentRecId));
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
        public virtual ActionResult Modify(long PaymentId)
        {
            Payment _model = _paymentRepository.FindById(PaymentId);
            if (_model == null)
            {
                return HttpNotFound();
            }
            var data = Mapper.Map<ViewModelCreateAndModifyDocumentPayment>(_model);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Modify(ViewModelCreateAndModifyDocumentPayment request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (_unitOfWorkFactory.Create())
                    {
                        Payment _payment = _paymentRepository.FindById(request.recId);
                        Mapper.Map(request, _payment, typeof(ViewModelCreateAndModifyDocumentPayment), typeof(Payment));
                        return RedirectToAction(MVC.Document.PaymentsList(request.DocumentRecId));
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
    }
}