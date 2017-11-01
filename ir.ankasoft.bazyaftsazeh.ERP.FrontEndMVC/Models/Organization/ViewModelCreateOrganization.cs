using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Communication;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.PostalAddress;
using ir.ankasoft.resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Organization
{
    public class ViewModelCreateOrganization
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        public long parentId { get; set; }

        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLenght100", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(Title), ResourceType = typeof(Resource))]
        public string Title { get; set; }

        [Required(ErrorMessageResourceName = "RequiredFiled", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(20, ErrorMessageResourceName = "MaxLenght20", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(RegisterationNumber), ResourceType = typeof(Resource))]
        public string RegisterationNumber { get; set; }

        [MaxLength(100, ErrorMessageResourceName = "MaxLenght100", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(RegisterationPlace), ResourceType = typeof(Resource))]
        public string RegisterationPlace { get; set; }

        [MaxLength(20, ErrorMessageResourceName = "MaxLenght20", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(CommercialNumber), ResourceType = typeof(Resource))]
        public string CommercialNumber { get; set; }

        public List<ViewModelCommunication> CommunicationCollection { get; set; }

        public List<ViewModelPostalAddress> PostalAddressCollection { get; set; }
    }
}