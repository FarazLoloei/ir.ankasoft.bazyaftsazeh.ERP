using System.Collections.Generic;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models
{
    public class Select2OptionModel
    {
        public long id { get; set; }
        public string text { get; set; }
    }
    public class ViewModelSelect2PagedResult
    {
        public int Total { get; set; }
        public List<Select2OptionModel> Results { get; set; }
    }
}