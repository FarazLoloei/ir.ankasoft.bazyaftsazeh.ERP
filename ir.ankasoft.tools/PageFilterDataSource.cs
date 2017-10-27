using ir.ankasoft.resource;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ir.ankasoft.tools
{
    public class PageFilterDataSource
    {
        [Display(Name = nameof(Resource.Search), ResourceType = typeof(Resource))]
        public string keyword { get; set; } = DefaultValues.EmptyString;

        public int page { get; set; } = DefaultValues.page;

        public int pageSize { get; set; } = DefaultValues.pageSize;

        public KeyValuePair<string, SortType> sort { get; set; } = new KeyValuePair<string, SortType>("recId", SortType.ASC);

        public List<SelectListItem> PageSizeCollection { get; set; } = DefaultValues.PageSizeCollection;
    }
}