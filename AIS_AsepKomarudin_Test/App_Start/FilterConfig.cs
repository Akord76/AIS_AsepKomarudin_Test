using System.Web;
using System.Web.Mvc;

namespace AIS_AsepKomarudin_Test
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
