using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YTrailerWebApp.Startup))]
namespace YTrailerWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
