using Microsoft.AspNet.SignalR.Hosting;
using System.Web;
using System.Web.Mvc;

namespace ttts
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            
            filters.Add(new HandleErrorAttribute());
        }
    }
}
