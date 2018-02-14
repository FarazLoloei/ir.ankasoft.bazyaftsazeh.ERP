using ir.ankasoft.bazyaftsazeh.ERP.entities.Enums;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Vehicle;
using ir.ankasoft.resource;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Document
{
    public class ViewModelModifyDocument
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
        [MaxLength(10, ErrorMessageResourceName = "MaxLenght100", ErrorMessageResourceType = typeof(Resource))]
        public string PaymentDateShamsi { get; set; }

        public bool IsAnyPaymentPaid { get; set; }

        [Display(Name = nameof(PaymentType), ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        public DocumentPaymentType PaymentType { get; set; }

        [Display(Name = nameof(AgreementPrice), ResourceType = typeof(Resource))]
        public string AgreementPrice { get; set; } = "0";

        [Display(Name = nameof(Serial), ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(10, ErrorMessageResourceName = "MaxLenght10", ErrorMessageResourceType = typeof(Resource))]
        public string Serial { get; set; }

        [Display(Name = nameof(Description), ResourceType = typeof(Resource))]
        public string Description { get; set; }

        //public long VehicleRecId { get; set; }

        public ViewModelCreateAndModifyVehicle Vehicle { get; set; } = new ViewModelCreateAndModifyVehicle();
    }
}