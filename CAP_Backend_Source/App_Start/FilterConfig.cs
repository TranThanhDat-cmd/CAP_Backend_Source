using System.Web;
using System.Web.Mvc;

namespace CAP_Backend_Source
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
