using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcBase.Web.UI.Startup))]
namespace MvcBase.Web.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
