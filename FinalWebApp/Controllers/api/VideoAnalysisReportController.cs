using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FinalWebApp.Models;

namespace FinalWebApp.Controllers.api
{
    public class VideoAnalysisReportController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/VideoAnalysisReport
        public IQueryable<VideoAnalysisReport> GetVideoAnalysisReports()
        {
            return db.VideoAnalysisReports;
        }

        // GET api/VideoAnalysisReport/5
        [ResponseType(typeof(VideoAnalysisReport))]
        public IHttpActionResult GetVideoAnalysisReport(int id)
        {
            VideoAnalysisReport videoanalysisreport = db.VideoAnalysisReports
                .Find(id);
            
            if (videoanalysisreport == null)
            {
                return NotFound();
            }

            return Ok(videoanalysisreport);
        }


        

        // PUT api/VideoAnalysisReport/5
        public async Task<IHttpActionResult> PutVideoAnalysisReport(int id, VideoAnalysisReport videoanalysisreport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != videoanalysisreport.Id)
            {
                return BadRequest();
            }

            db.Entry(videoanalysisreport).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoAnalysisReportExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/VideoAnalysisReport
        [ResponseType(typeof(VideoAnalysisReport))]
        public async Task<IHttpActionResult> PostVideoAnalysisReport(VideoAnalysisReport videoanalysisreport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VideoAnalysisReports.Add(videoanalysisreport);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = videoanalysisreport.Id }, videoanalysisreport);
        }

        // DELETE api/VideoAnalysisReport/5
        [ResponseType(typeof(VideoAnalysisReport))]
        public async Task<IHttpActionResult> DeleteVideoAnalysisReport(int id)
        {
            VideoAnalysisReport videoanalysisreport = await db.VideoAnalysisReports.FindAsync(id);
            if (videoanalysisreport == null)
            {
                return NotFound();
            }

            db.VideoAnalysisReports.Remove(videoanalysisreport);
            await db.SaveChangesAsync();

            return Ok(videoanalysisreport);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VideoAnalysisReportExists(int id)
        {
            return db.VideoAnalysisReports.Count(e => e.Id == id) > 0;
        }
    }
}