using ir.ankasoft.bazyaftsazeh.ERP.entities.Enums;
using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Document
{
    public class ViewModelDisplayDocument
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        [Display(Name = nameof(LastOwner), ResourceType = typeof(Resource))]
        public string LastOwner { get; set; }

        [Display(Name = nameof(PlateOwner), ResourceType = typeof(Resource))]
        public string PlateOwner { get; set; }

        [Display(Name = nameof(Vehicle), ResourceType = typeof(Resource))]
        public string Vehicle { get; set; }

        [Display(Name = nameof(PaymentDateShamsi), ResourceType = typeof(Resource))]
        public string PaymentDateShamsi { get; set; }

        [Display(Name = nameof(PlateNumber), ResourceType = typeof(Resource))]
        public string PlateNumber { get; set; }

        [Display(Name = nameof(PlanType), ResourceType = typeof(Resource))]
        public PlanType PlanType { get; set; }

        [Display(Name = nameof(TotalCostValue), ResourceType = typeof(Resource))]
        public string TotalCostValueDisplayMode
        {
            get
            {
                return tools.Convert.GroupDigiting(TotalCostValue, 0);
            }
        }

        [Display(Name = nameof(TotalCostValue), ResourceType = typeof(Resource))]
        public double TotalCostValue { get; set; }
    }
}