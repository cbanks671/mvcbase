using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvcbase.web.ui.Startup))]
namespace mvcbase.web.ui
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
