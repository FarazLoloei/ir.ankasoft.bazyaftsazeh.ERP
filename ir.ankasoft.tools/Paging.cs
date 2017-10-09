using System;

namespace ir.ankasoft.tools
{
    public static class Paging
    {
        public static int ComputePageCount(int itemsCount, int pageSize = DefaultValues.pageSize)
        {
            double pageCount = itemsCount * 1.0 / pageSize;

            if (pageCount != Math.Floor(pageCount)) pageCount++;
            return System.Convert.ToInt32(Math.Floor(pageCount));
            //return Convert.ToInt32(Math.Floor(itemsCount * 1.0 / DefaultValues.PageSize)) + 1;
        }
    }
}