using ir.ankasoft.bazyaftsazeh.ERP.entities.Enums;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentCost;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentImperfection;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.GovernmentPlan;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Payment;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.ReplacementPlan;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Vehicle;
using ir.ankasoft.resource;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Document
{
    public class ViewModelCreateDocument
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        [Display(Name = nameof(LastOwner), ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        public string LastOwnerRecId { get; set; }

        public List<SelectListItem> LastOwner { get; set; } = new List<SelectListItem>();

        [Display(Name = nameof(PlateOwner), ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        public string PlateOwnerRecId { get; set; }

        public List<SelectListItem> PlateOwner { get; set; }

        [Display(Name = nameof(Investor), ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        public string InvestorRecId { get; set; }

        public List<SelectListItem> Investor { get; set; }

        [Display(Name = nameof(Contractor), ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        public string ContractorRecId { get; set; }

        public List<SelectListItem> Contractor { get; set; }

        [Display(Name = nameof(PaymentDateShamsi), ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(10, ErrorMessageResourceName = "MaxLenght10", ErrorMessageResourceType = typeof(Resource))]
        public string PaymentDateShamsi { get; set; }

        [Display(Name = nameof(AgreementPrice), ResourceType = typeof(Resource))]
        public string AgreementPrice { get; set; } = "0";

        [Display(Name = nameof(Serial), ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(10, ErrorMessageResourceName = "MaxLenght10", ErrorMessageResourceType = typeof(Resource))]
        public string Serial { get; set; }

        [Display(Name = nameof(Description), ResourceType = typeof(Resource))]
        public string Description { get; set; }

        public List<ViewModelCreateAndModifyDocumentCost> CostCollection { get; set; }

        public List<ViewModelCreateAndModifyDocumentImperfection> ImperfectionCollection { get; set; }

        [Display(Name = nameof(PaymentType), ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        public DocumentPaymentType PaymentType { get; set; }

        public List<ViewModelCreateAndModifyPayment> PaymentCollection { get; set; }

        [Display(Name = nameof(PlanType), ResourceType = typeof(Resource))]
        public PlanType PlanType { get; set; } = PlanType.Cash;

        public ViewModelCreateReplacementPlan ReplacementPlan { get; set; } = new ViewModelCreateReplacementPlan();

        public ViewModelCreateGovernmentPlan GovernmentPlan { get; set; } = new ViewModelCreateGovernmentPlan();

        public ViewModelCreateAndModifyVehicle Vehicle { get; set; } = new ViewModelCreateAndModifyVehicle();
    }
}