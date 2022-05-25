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
    public class RequestController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Request/
        public ActionResult Index()
        {
           // var reqs = db.PromoRequests.ToList();

            var list = db.PromoRequests
                .ToList();

            foreach (var promorequest in list)
            {
                getAndUpdateProjectIds(promorequest);
            }
            
            return View(list);
        }

        private void getAndUpdateProjectIds(PromoRequest promorequest)
        {
            promorequest.ProjectIds =
                string.Join(",",
                db.PromoProjects
                .Where(x => x.PromoRequestId == promorequest.Id)
                 .Select(x => x.Id));
        }

        // GET: /Request/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromoRequest promorequest = db.PromoRequests.Find(id);
            
            if (promorequest == null)
            {
                return HttpNotFound();
            }
            getAndUpdateProjectIds(promorequest);
            return View(promorequest);
        }

        // GET: /Request/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Request/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,YoutTubeUrl,Status")] PromoRequest promorequest)
        {
            if (ModelState.IsValid)
            {
                promorequest.Status = ePromoStatus.NotStarted;
                db.PromoRequests.Add(promorequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(promorequest);
        }

        // GET: /Request/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromoRequest promorequest = db.PromoRequests.Find(id);

            if (promorequest == null)
            {
                return HttpNotFound();
            }
            getAndUpdateProjectIds(promorequest);
            return View(promorequest);
        }

        // POST: /Request/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,YoutTubeUrl,Status")] PromoRequest promorequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promorequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(promorequest);
        }

        // GET: /Request/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromoRequest promorequest = db.PromoRequests.Find(id);
            if (promorequest == null)
            {
                return HttpNotFound();
            }
            return View(promorequest);
        }

        // POST: /Request/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PromoRequest promorequest = db.PromoRequests.Find(id);
            db.PromoRequests.Remove(promorequest);
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
