using ir.ankasoft.tools;
using System.Collections.Generic;

namespace ir.ankasoft.infrastructure
{
    public interface IFilterDataSource//<T>
    {
        string keyword { get; set; }

        int page { get; set; }

        int pageSize { get; set; }

        KeyValuePair<string, SortType> sort { get; set; }

        //List<T> PageSizeCollection { get; set; }

        KeyValuePair<string, string> Filter { get; set; }
    }
}