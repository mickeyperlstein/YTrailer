using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using YTrailerWeb.Models;
using YTrailerWeb.Models;

namespace YTrailerWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(Server.MapPath("~/log4net.config")));

            //System.Data.Entity.Database.SetInitializer<MyDB>(
            //    new System.Data.Entity.DropCreateDatabaseIfModelChanges<MyDB>());

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register); 
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            LoadPromoMaker();
        }


        private  void LoadPromoMaker()
        {
            //PromoAsyncQueue promoQueue;
            string connstr = "";
            using (var db = new MyDBContext())
            {
                connstr = db.Database.Connection.ConnectionString;
               Debug.WriteLine (connstr);
                /*
                 * Data Source=(localdb)\v11.0;AttachDbFilename=|DataDirectory|CoreEngine.Models.MyDB.mdf;Initial Catalog=CoreEngine.Models.MyDB;Integrated Security=True;MultipleActiveResultSets=True
                 * 
                 * 
                 */
            }

              //promoQueue = new PromoAsyncQueue(connstr);
             //  promoQueue.RunAsync();
        }
    }
}
