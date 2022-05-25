using Microsoft.Owin;
using Owin;
using YTrailerWeb.Models;

[assembly: OwinStartupAttribute(typeof(YTrailerWeb.Startup))]
namespace YTrailerWeb
{
    public partial class Startup
    {
        #region Logging

        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
     
        public void Configuration(IAppBuilder app)
        {
            logger.Info("Starting up webApp");    
            ConfigureAuth(app);
        }

       

        

    }
}
