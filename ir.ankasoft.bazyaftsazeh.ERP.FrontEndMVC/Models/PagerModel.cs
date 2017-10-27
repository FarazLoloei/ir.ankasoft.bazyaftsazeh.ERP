﻿using ir.ankasoft.resource;
using ir.ankasoft.tools;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC
{
    public class PagerModel<T> where T : class
    {
        public IEnumerable<T> Data { get; set; }
        public PagerData PageData { get; set; }
    }

    public class PagerData
    {
        public PageFilterDataSource filter { get; set; }
        //public List<SelectListItem> PageSizeCollection { get; set; } = DefaultValues.PageSizeCollection;
        //public int PageSize { get; set; }
        //public int CurrentPage { get; set; }
        public int TotalRows { get; set; }
        public int PageCount
        {
            get
            {
                return Paging.ComputePageCount(TotalRows);
            }
        }
        //public KeyValuePair<string, SortType> Sort { get; set; } = new KeyValuePair<string, SortType>("Id", SortType.ASC);

        //[Display(Name = nameof(Resource.Search), ResourceType = typeof(Resource))]
        //public string Keyword { get; set; }
    }
}