using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalWebApp.Startup))]
namespace FinalWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
