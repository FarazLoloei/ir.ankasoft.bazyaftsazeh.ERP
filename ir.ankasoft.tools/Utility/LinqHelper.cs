using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir.ankasoft.tools.Utility
{
    public class LinqHelper
    {
        public static string LinqOrderByBuilder(string sortOn, string sortDirection)
        {
            if (sortOn == null) return " 0";
            return string.Format("{0} {1}", sortOn.Replace('_', '.'), sortDirection);
        }
    }
}
