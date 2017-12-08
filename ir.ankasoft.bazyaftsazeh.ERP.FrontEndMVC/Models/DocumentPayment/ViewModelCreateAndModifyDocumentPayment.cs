using ir.ankasoft.bazyaftsazeh.ERP.entities.Enums;
using ir.ankasoft.resource;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentPayment
{
    public class ViewModelCreateAndModifyDocumentPayment
    {
        [HiddenInput(DisplayValue = false)]
        public long DocumentRecId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        [Display(Name = nameof(Title), ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        public string Title { get; set; }

        [Display(Name = nameof(Value), ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        public double Value { get; set; }

        [Display(Name = nameof(Value), ResourceType = typeof(Resource))]
        public string ValueDisplayMode { get { return tools.Convert.GroupDigiting(Value, 0); } }

        [Display(Name = nameof(TransactionDateShamsi), ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        public string TransactionDateShamsi { get; set; }

        [Display(Name = nameof(DueDateShamsi), ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        public string DueDateShamsi { get; set; }

        [Display(Name = nameof(PaymentType), ResourceType = typeof(Resource))]
        public PaymentType PaymentType { get; set; } = PaymentType.Cash;

        public override string ToString()
        {
            return $"{Title} - {ValueDisplayMode}";
        }
    }
}