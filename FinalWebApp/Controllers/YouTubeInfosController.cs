using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalWebApp.Models;

namespace FinalWebApp.Controllers
{
    public class YouTubeInfosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /YouTubeInfos/
        public ActionResult Index()
        {
            var youtubeinfos = db.YouTubeInfos.Include(y => y.PromoRequest);
            return View(youtubeinfos.ToList());
        }

        // GET: /YouTubeInfos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YouTubeInfos youtubeinfos = db.YouTubeInfos.Find(id);
            if (youtubeinfos == null)
            {
                return HttpNotFound();
            }
            return View(youtubeinfos);
        }

        // GET: /YouTubeInfos/Create
        public ActionResult Create()
        {
            ViewBag.PromoRequestId = new SelectList(db.PromoRequests, "Id", "YoutTubeUrl");
            return View();
        }

        // POST: /YouTubeInfos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,PromoRequestId,Title,Description")] YouTubeInfos youtubeinfos)
        {
            if (ModelState.IsValid)
            {

                using (api.YouTubeController ytbc = new api.YouTubeController())
                {

                    ytbc.PostYouTubeInfos(youtubeinfos);


                    return RedirectToAction("Index");
                }
            }

            ViewBag.PromoRequestId = new SelectList(db.PromoRequests, "Id", "YoutTubeUrl", youtubeinfos.PromoRequestId);
            return View(youtubeinfos);
        }

        // GET: /YouTubeInfos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YouTubeInfos youtubeinfos = db.YouTubeInfos.Find(id);
            if (youtubeinfos == null)
            {
                return HttpNotFound();
            }
            ViewBag.PromoRequestId = new SelectList(db.PromoRequests, "Id", "YoutTubeUrl", youtubeinfos.PromoRequestId);
            return View(youtubeinfos);
        }

        // POST: /YouTubeInfos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,PromoRequestId,Title,Description")] YouTubeInfos youtubeinfos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(youtubeinfos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PromoRequestId = new SelectList(db.PromoRequests, "Id", "YoutTubeUrl", youtubeinfos.PromoRequestId);
            return View(youtubeinfos);
        }

        // GET: /YouTubeInfos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YouTubeInfos youtubeinfos = db.YouTubeInfos.Find(id);
            if (youtubeinfos == null)
            {
                return HttpNotFound();
            }
            return View(youtubeinfos);
        }

        // POST: /YouTubeInfos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YouTubeInfos youtubeinfos = db.YouTubeInfos.Find(id);
            db.YouTubeInfos.Remove(youtubeinfos);
            db.SaveChanges();
            return RedirectToAction("Index");
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
