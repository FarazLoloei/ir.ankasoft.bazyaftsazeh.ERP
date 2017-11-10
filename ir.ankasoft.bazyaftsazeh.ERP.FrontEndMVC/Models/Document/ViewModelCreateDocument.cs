using ir.ankasoft.bazyaftsazeh.ERP.entities.Enums;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Cost;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentCost;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentImperfection;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Imperfection;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Party;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Payment;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Vehicle;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Document
{
    public class ViewModelCreateDocument
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        [Display(Name = nameof(LastOwner), ResourceType = typeof(Resource))]
        public long LastOwnerRecId { get; set; }

        public List<SelectListItem> LastOwner { get; set; }

        [Display(Name = nameof(PlateOwner), ResourceType = typeof(Resource))]
        public long PlateOwnerRecId { get; set; }

        public List<SelectListItem> PlateOwner { get; set; }

        [Display(Name = nameof(Investor), ResourceType = typeof(Resource))]
        public long InvestorRecId { get; set; }

        public List<SelectListItem> Investor { get; set; }

        [Display(Name = nameof(Contractor), ResourceType = typeof(Resource))]
        public long ContractorRecId { get; set; }

        public List<SelectListItem> Contractor { get; set; }

        [Display(Name = nameof(Vehicle), ResourceType = typeof(Resource))]
        public ViewModelCreateAndModifyVehicle Vehicle { get; set; }

        [Display(Name = nameof(PaymentDate), ResourceType = typeof(Resource))]
        public string PaymentDate { get; set; }

        public List<ViewModelDisplayDocumentCost> CostCollection { get; set; }

        public List<ViewModelDisplayDocumentImperfection> ImperfectionCollection { get; set; }

        [Display(Name = nameof(PaymentType), ResourceType = typeof(Resource))]
        public DocumentPaymentType PaymentType { get; set; }

        public List<ViewModelCreateAndModifyPayment> PaymentCollection { get; set; }



        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLenght100", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(Name), ResourceType = typeof(Resource))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLenght100", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(Family), ResourceType = typeof(Resource))]
        public string Family { get; set; }

        [MaxLength(100, ErrorMessageResourceName = "MaxLenght20", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(ImporterNumber), ResourceType = typeof(Resource))]
        public string ImporterNumber { get; set; }


        //public List<ViewModelPostalAddress> PostalAddressCollection { get; set; }
    }
}