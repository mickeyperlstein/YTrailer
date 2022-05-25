using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FinalWebApp.Models;
using FinalWebApp.Controllers.api;

namespace FinalWebApp.Controllers
{
    public class PromoRequestController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/PromoRequest
        public IQueryable<PromoRequest> GetPromoRequests()
        {
            return db.PromoRequests;
        }

        // GET api/PromoRequest/5
        [ResponseType(typeof(PromoRequest))]
        public IHttpActionResult GetPromoRequest(int id)
        {
            PromoRequest promorequest = db.PromoRequests.Find(id);
            if (promorequest == null)
            {
                return NotFound();
            }

            return Ok(promorequest);
        }

        // PUT api/PromoRequest/5
        // UPDATE
        public IHttpActionResult PutPromoRequest(int id, PromoRequest promorequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != promorequest.Id)
            {
                return BadRequest();
            }


            if (promorequest.Status == ePromoStatus.ReadyToCreatePromo)
            {
               // CreateNewProject(promorequest);
            }

            db.Entry(promorequest).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromoRequestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.Accepted);
        }

        private  void CreateNewProject(PromoRequest promorequest)
        {
            PromoProjectController pc = new PromoProjectController();
            PromoProject proj = new PromoProject();


            var youtubeInfo = db.YouTubeInfos
                .Where(x => x.PromoRequestId == promorequest.Id)
                .FirstOrDefault();
            proj.StartingTitle = youtubeInfo.Title;
            proj.MidTitle = youtubeInfo.Description;

            pc.PostPromoProject(proj);
        }

        // POST api/PromoRequest
        // INSERT
        [ResponseType(typeof(PromoRequest))]
        public IHttpActionResult PostPromoRequest(PromoRequest promorequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (promorequest.Id > 0)
                db.Entry(promorequest).State = EntityState.Modified;
            else
            db.PromoRequests.Add(promorequest);

            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = promorequest.Id }, promorequest);
        }

        // DELETE api/PromoRequest/5
        [ResponseType(typeof(PromoRequest))]
        public IHttpActionResult DeletePromoRequest(int id)
        {
            PromoRequest promorequest = db.PromoRequests.Find(id);
            if (promorequest == null)
            {
                return NotFound();
            }

            db.PromoRequests.Remove(promorequest);
            db.SaveChanges();

            return Ok(promorequest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PromoRequestExists(int id)
        {
            return db.PromoRequests.Count(e => e.Id == id) > 0;
        }
    }
}