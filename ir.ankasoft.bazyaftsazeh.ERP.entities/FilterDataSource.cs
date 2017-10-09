using ir.ankasoft.infrastructure;
using ir.ankasoft.tools;
using System.Collections.Generic;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities
{
    public class FilterDataSource : IFilterDataSource
    {
        public string keyword { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public KeyValuePair<string, SortType> sort { get; set; }
        public KeyValuePair<string, string> Filter { get; set; }
    }
}