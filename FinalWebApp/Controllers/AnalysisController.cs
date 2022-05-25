using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalWebApp.Models;

namespace FinalWebApp.Controllers
{
    public class AnalysisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Analysis/
        public async Task<ActionResult> Index()
        {
            return View(await db.VideoAnalysisReports.ToListAsync());
        }

        // GET: /Analysis/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoAnalysisReport videoanalysisreport = await db.VideoAnalysisReports.FindAsync(id);
            if (videoanalysisreport == null)
            {
                return HttpNotFound();
            }
            return View(videoanalysisreport);
        }

        // GET: /Analysis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Analysis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,PromoRequest,OriginalVideo,LowResVideoFile")] VideoAnalysisReport videoanalysisreport)
        {
            if (ModelState.IsValid)
            {
                db.VideoAnalysisReports.Add(videoanalysisreport);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(videoanalysisreport);
        }

        // GET: /Analysis/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoAnalysisReport videoanalysisreport = await db.VideoAnalysisReports.FindAsync(id);
            if (videoanalysisreport == null)
            {
                return HttpNotFound();
            }
            return View(videoanalysisreport);
        }

        // POST: /Analysis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,PromoRequest,OriginalVideo,LowResVideoFile")] VideoAnalysisReport videoanalysisreport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoanalysisreport).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(videoanalysisreport);
        }

        // GET: /Analysis/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoAnalysisReport videoanalysisreport = await db.VideoAnalysisReports.FindAsync(id);
            if (videoanalysisreport == null)
            {
                return HttpNotFound();
            }
            return View(videoanalysisreport);
        }

        // POST: /Analysis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VideoAnalysisReport videoanalysisreport = await db.VideoAnalysisReports.FindAsync(id);
            db.VideoAnalysisReports.Remove(videoanalysisreport);
            await db.SaveChangesAsync();
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
