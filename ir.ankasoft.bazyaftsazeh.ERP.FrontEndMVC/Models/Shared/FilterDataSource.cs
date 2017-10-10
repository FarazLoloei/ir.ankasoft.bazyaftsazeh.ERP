using ir.ankasoft.infrastructure;
using ir.ankasoft.resource;
using ir.ankasoft.tools;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models
{
    public class FilterDataSource : IFilterDataSource
    {
        [Display(Name = nameof(Resource.Search), ResourceType = typeof(Resource))]
        private string _keyword = DefaultValues.EmptyString;
        public string keyword { get { return _keyword ?? DefaultValues.EmptyString; } set { _keyword = value; } }

        public int page { get; set; } = DefaultValues.page;
        public int pageSize { get; set; } = DefaultValues.pageSize;
        public KeyValuePair<string, SortType> sort { get; set; } = new KeyValuePair<string, SortType>("recId", SortType.ASC);
        public List<SelectListItem> PageSizeCollection { get; set; } = DefaultValues.PageSizeCollection;
        public KeyValuePair<string, string> Filter { get; set; }
    }
}