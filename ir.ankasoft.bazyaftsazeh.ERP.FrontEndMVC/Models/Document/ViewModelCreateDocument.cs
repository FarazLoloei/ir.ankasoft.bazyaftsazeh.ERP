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
        public string LastOwnerRecId { get; set; }

        public List<SelectListItem> LastOwner { get; set; } = new List<SelectListItem>();

        [Display(Name = nameof(PlateOwner), ResourceType = typeof(Resource))]
        public string PlateOwnerRecId { get; set; }

        public List<SelectListItem> PlateOwner { get; set; }

        [Display(Name = nameof(Investor), ResourceType = typeof(Resource))]
        public string InvestorRecId { get; set; }

        public List<SelectListItem> Investor { get; set; }

        [Display(Name = nameof(Contractor), ResourceType = typeof(Resource))]
        public string ContractorRecId { get; set; }

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

        public PlanType PlanType { get; set; }

        /*Replacement*/
        [Display(Name = nameof(BeneficiaryImporter), ResourceType = typeof(Resource))]
        public long BeneficiaryImporterRecId { get; set; }

        public List<SelectListItem> BeneficiaryImporter { get; set; } = new List<SelectListItem>();

        [Display(Name = nameof(Importer), ResourceType = typeof(Resource))]
        public long ReplacementVehicleRecId { get; set; }

        public List<SelectListItem> ReplacementVehicle { get; set; }

        [Display(Name = nameof(Representor), ResourceType = typeof(Resource))]
        public string RepresentorRecId { get; set; }
        
        public List<SelectListItem> Representor { get; set; } = new List<SelectListItem>();

        /*Government*/
        [Display(Name = nameof(Organization), ResourceType = typeof(Resource))]
        public long OrganizationRecId { get; set; }

        public List<SelectListItem> Organization { get; set; } = new List<SelectListItem>();

        [Display(Name = nameof(PermissionNumber), ResourceType = typeof(Resource))]
        public string PermissionNumber { get; set; }


    }
}