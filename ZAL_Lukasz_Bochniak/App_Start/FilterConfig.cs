using System.Web;
using System.Web.Mvc;

namespace ZAL_Lukasz_Bochniak
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
