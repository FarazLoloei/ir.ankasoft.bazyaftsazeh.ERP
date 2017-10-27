using System.Collections.Generic;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models
{
    public class ViewModelWithSelectList<T>
    {
        public ViewModelWithSelectList()
        {
            selectList = new Dictionary<string, List<SelectListItem>>();
        }

        public T data { get; set; }

        public Dictionary<string, List<SelectListItem>> selectList { get; set; }
    }
}