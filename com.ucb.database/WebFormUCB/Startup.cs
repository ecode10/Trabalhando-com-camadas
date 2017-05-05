using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormUCB.Startup))]
namespace WebFormUCB
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
