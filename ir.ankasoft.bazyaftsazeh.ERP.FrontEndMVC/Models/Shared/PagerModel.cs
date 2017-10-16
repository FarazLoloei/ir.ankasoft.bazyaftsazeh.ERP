using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models;
using ir.ankasoft.tools;
using System.Collections.Generic;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC
{
    public class PagerModel<T> where T : class
    {
        public IEnumerable<T> Data { get; set; }
        public PagerData PageData { get; set; }
        public T filter { get; set; }
    }

    public class PagerData
    {
        public FilterDataSource filterDataSource { get; set; }
        public int TotalRows { get; set; }

        public int PageCount
        {
            get
            {
                return Paging.ComputePageCount(TotalRows, filterDataSource.pageSize);
            }
        }
    }
}