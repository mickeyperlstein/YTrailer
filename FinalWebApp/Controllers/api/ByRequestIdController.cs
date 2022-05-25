using FinalWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace FinalWebApp.Controllers.api
{
    public class ByRequestIdController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/ByRequestId/PromoProject/5
        [ResponseType(typeof(PromoProject))]
        [HttpGet]
        public IHttpActionResult PromoProject(int id)
        {
            PromoProject item = db
                .PromoProjects
                .Where(x=> x.PromoRequestId==id)
                .OrderByDescending(x=> x.Id)
                .FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // GET api/ByRequestId/VideoAnalysisReport/5
        [ResponseType(typeof(VideoAnalysisReport))]
        [HttpGet]
        public IHttpActionResult VideoAnalysisReport (int id)
        {
            VideoAnalysisReport item = db
                .VideoAnalysisReports
                .Where(x => x.PromoRequestId == id)
                .FirstOrDefault();

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // GET api/ByRequestId/YouTubeInfos/5
        [ResponseType(typeof(YouTubeInfos))]
        [HttpGet]
        public IHttpActionResult YouTubeInfos(int id)
        {
            YouTubeInfos item = db
                .YouTubeInfos
                .Where(x => x.PromoRequestId == id)
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
    }
}
