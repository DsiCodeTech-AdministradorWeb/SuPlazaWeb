using System.Web;
using System.Web.Mvc;

namespace DsiCodetech.Administrador.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
