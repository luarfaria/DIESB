using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DIESB.Web.Startup))]
namespace DIESB.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
