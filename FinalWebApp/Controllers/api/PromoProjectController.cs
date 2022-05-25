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
using System.Data.Entity.Validation;

namespace FinalWebApp.Controllers.api
{
    public class PromoProjectController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/PromoProject
        public IQueryable<PromoProject> GetPromoProjects()
        {
            return db.PromoProjects;
        }

        // GET api/PromoProject/5
        [ResponseType(typeof(PromoProject))]
        public async Task<IHttpActionResult> GetPromoProject(int id)
        {
            PromoProject promoproject = await db.PromoProjects.FindAsync(id);
            if (promoproject == null)
            {
                return NotFound();
            }

            return Ok(promoproject);
        }

        // PUT api/PromoProject/5
        /// <summary>
        /// UPDATE
        /// </summary>
        /// <param name="id"></param>
        /// <param name="promoproject"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> PutPromoProject(int id, PromoProject promoproject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != promoproject.Id)
            {
                return BadRequest();
            }

            db.Entry(promoproject).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromoProjectExists(id))
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

        // POST api/PromoProject
        /// <summary>
        /// INSERT
        /// </summary>
        /// <param name="promoproject"></param>
        /// <returns></returns>
        [ResponseType(typeof(PromoProject))]
        public  IHttpActionResult PostPromoProject(PromoProject promoproject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

             db.PromoProjects.Add(promoproject);
             try
             {
                 int changes = db.SaveChanges();
                 int y = 4;

             }


             catch (DbEntityValidationException dbEx)
             {
                 var t = dbEx.ToString();
                 var y = t + "...";
             }
             catch (InvalidOperationException ioe)
             {
                 return BadRequest(ioe.Message);
             }
             catch (Exception e)
             {
                 return BadRequest(e.Message);
             }


            return CreatedAtRoute("DefaultApi", new { id = promoproject.Id }, promoproject);
        }

        // DELETE api/PromoProject/5
        [ResponseType(typeof(PromoProject))]
        public async Task<IHttpActionResult> DeletePromoProject(int id)
        {
            PromoProject promoproject = await db.PromoProjects.FindAsync(id);
            if (promoproject == null)
            {
                return NotFound();
            }

            db.PromoProjects.Remove(promoproject);
            await db.SaveChangesAsync();

            return Ok(promoproject);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PromoProjectExists(int id)
        {
            return db.PromoProjects.Count(e => e.Id == id) > 0;
        }
    }
}