using SellPhones.Celulares.Web.Filters;
using System.Web;
using System.Web.Mvc;

namespace SellPhones.Celulares.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogActionFilter());
        }
    }
}
