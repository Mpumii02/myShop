using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(myShop.WebUI.Startup))]
namespace myShop.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
