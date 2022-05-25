using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using YTrailerWeb.Models;

namespace YTrailerWeb.Controllers
{
    public class TaskAPIController : ApiController
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private MyDBContext db = new MyDBContext();

        public TaskAPIController()
        {
          
               
        }
        // GET api/TaskAPI/GetStatus
       
        [System.Web.Http.HttpGet]
        public bool GetStatus() { return true; }
        // GET api/TaskAPI
        public IEnumerable<YTask> GetTasks() { return GetTasks(""); }
        protected IEnumerable<YTask> GetTasks( string next)
        {
            var q = db.Tasks
                .Where(x => x.EndTime == null 
                           && x.isHandled == false);
            
            IEnumerable<YTask> ret = null;

            if ( next.ToUpper() == "NEXT" )
            {
                ret  = q.Take(1).AsEnumerable()
                    .Select(z => 
                    {
                        z.isHandled = true; 
                        return z; 
                    }).ToList();
            }
            else
            {
                ret = q.AsEnumerable();
            }

            
            logger.DebugFormat(" TaskAPI:Tasks({0})", ret.Count());


            return ret;
                //.Select(x => new
                //{
                //    YouTubeUrl = x.YouTubeUrl
                //    ,StateStr = x.State.ToString(),
                //    State = x.State,
                //    StartDate = x.State,
                //    EndDate = x.EndTime,
                //});
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}