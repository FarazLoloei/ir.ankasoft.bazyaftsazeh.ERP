using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new AuthorizeAttribute());
        }
    }
}