using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRUDINMVC.Startup))]
namespace CRUDINMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
