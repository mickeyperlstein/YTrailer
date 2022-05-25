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

namespace FinalWebApp.Controllers.api
{
    public class YouTubeController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/YouTube
        public IQueryable<YouTubeInfos> GetYouTubeInfos()
        {
            return db.YouTubeInfos;
        }

        // GET api/YouTube/5
        [ResponseType(typeof(YouTubeInfos))]
        public IHttpActionResult GetYouTubeInfos(int id)
        {
            YouTubeInfos youtubeinfos = db.YouTubeInfos.Find(id);
            if (youtubeinfos == null)
            {
                return NotFound();
            }

            return Ok(youtubeinfos);
        }

        // PUT api/YouTube/5
        // UPDATE
        public IHttpActionResult PutYouTubeInfos(int id, YouTubeInfos youtubeinfos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != youtubeinfos.Id)
            {
                return BadRequest();
            }

            db.Entry(youtubeinfos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YouTubeInfosExists(id))
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

        // POST api/YouTube
        // INSERT
        [ResponseType(typeof(YouTubeInfos))]
        public IHttpActionResult PostYouTubeInfos(YouTubeInfos youtubeinfos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //youtubeinfos.PromoRequest = null;
            //youtubeinfos.PromoRequestId = 0;
            db.YouTubeInfos.Add(youtubeinfos);


            //var promo = db.PromoRequests.Where(x => x.Id == youtubeinfos.PromoRequestId).FirstOrDefault();
            
            //promo.Status = ePromoStatus.GettingYouTubeDetails;
            //db.Entry(promo).State = EntityState.Modified;

            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = youtubeinfos.Id }, youtubeinfos);
        }

        // DELETE api/YouTube/5
        [ResponseType(typeof(YouTubeInfos))]
        public IHttpActionResult DeleteYouTubeInfos(int id)
        {
            YouTubeInfos youtubeinfos = db.YouTubeInfos.Find(id);
            if (youtubeinfos == null)
            {
                return NotFound();
            }

            db.YouTubeInfos.Remove(youtubeinfos);
            db.SaveChanges();

            return Ok(youtubeinfos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool YouTubeInfosExists(int id)
        {
            return db.YouTubeInfos.Count(e => e.Id == id) > 0;
        }
    }
}