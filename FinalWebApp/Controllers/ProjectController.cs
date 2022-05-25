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
    public class ProjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Project/
        public async Task<ActionResult> Index()
        {
            return View(await db.PromoProjects.ToListAsync());
        }
        [HttpGet]
       
        public async Task<ActionResult> Show(int id)
        {
            return View("Index",await db.PromoProjects
                                .Where(x=> x.PromoRequestId == id)
                                .ToListAsync());
        }

        // GET: /Project/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromoProject promoproject = await db.PromoProjects.FindAsync(id);
            if (promoproject == null)
            {
                return HttpNotFound();
            }
            return View(promoproject);
        }

        // GET: /Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,YouTubeInfosId,PromoRequestId,StartingTitle,MidTitle,MidTitle2,EndTitle,BgMusicFile,secs")] PromoProject promoproject)
        {
            if (ModelState.IsValid)
            {
                db.PromoProjects.Add(promoproject);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(promoproject);
        }

        // GET: /Project/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromoProject promoproject = await db.PromoProjects.FindAsync(id);
            if (promoproject == null)
            {
                return HttpNotFound();
            }
            return View(promoproject);
        }

        // POST: /Project/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,YouTubeInfosId,PromoRequestId,StartingTitle,MidTitle,MidTitle2,EndTitle,BgMusicFile,secs")] PromoProject promoproject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promoproject).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(promoproject);
        }

        // GET: /Project/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromoProject promoproject = await db.PromoProjects.FindAsync(id);
            if (promoproject == null)
            {
                return HttpNotFound();
            }
            return View(promoproject);
        }

        // POST: /Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PromoProject promoproject = await db.PromoProjects.FindAsync(id);
            db.PromoProjects.Remove(promoproject);
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
