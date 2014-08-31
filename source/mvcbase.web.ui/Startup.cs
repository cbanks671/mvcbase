using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcBase.web.ui.Startup))]
namespace MvcBase.web.ui
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
