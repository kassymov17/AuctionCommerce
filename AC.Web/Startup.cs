using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AC.Web.Startup))]
namespace AC.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
