using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ttts.Startup))]
namespace ttts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
