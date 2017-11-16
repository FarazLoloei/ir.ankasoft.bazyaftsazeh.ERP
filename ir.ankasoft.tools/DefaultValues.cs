﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ir.ankasoft.tools
{
    public class DefaultValues
    {
        public const int pageSize = 5;
        public const int page = 1;
        public const string EmptyString = "";
        public const string DefaultCurrency = "ریال";

        private static List<int> _pageSizeCollection = new List<int> { 5, 10, 25, 50, 100 };

        public static List<SelectListItem> PageSizeCollection
        {
            get
            {
                return _pageSizeCollection.Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.ToString()
                                  }).ToList();
            }
        }
    }

    public enum SortType
    {
        ASC = 1,
        DESC
    }
}