using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(ttts.App_Start.Startup1))]

namespace ttts.App_Start
{
    public class Startup1
    {
        
        public void Configuration(IAppBuilder app)
        {
           // app.MapSignalR<MyConnection1>("/myconnection");//同域访问

            //跨域访问
            app.MapSignalR<MyConnection1>("/myconnection", new ConnectionConfiguration()
            {
                EnableJSONP = true
            });

            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
