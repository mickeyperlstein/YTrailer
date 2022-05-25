using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YTrailerWeb.Models;

namespace YTrailerWeb.Controllers
{
    public class TaskController : Controller
    {

        #region Logging 
        
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        private MyDBContext db = new MyDBContext();
        
        // GET: /Task/
        public async Task<ActionResult> Index()
        {
            return View(await db.Tasks.ToListAsync());
        }

        // GET: /Task/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YTask ytask = await db.Tasks.FindAsync(id);
            if (ytask == null)
            {
                return HttpNotFound();
            }
            return View(ytask);
        }

        // GET: /Task/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Task/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="YouTubeUrl")] YTask ytask)
        {
            if (ModelState.IsValid)
            {
                ytask.YTaskState = YTaskState.e10_YouTubeDetails;
                ytask.StartDate = DateTime.UtcNow;
                db.Tasks.Add(ytask);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ytask);
        }

        // GET: /Task/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YTask ytask = await db.Tasks.FindAsync(id);
            if (ytask == null)
            {
                return HttpNotFound();
            }
            return View(ytask);
        }

        // POST: /Task/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,YouTubeUrl,State,StartDate,EndTime")] YTask ytask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ytask).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ytask);
        }

        // GET: /Task/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YTask ytask = await db.Tasks.FindAsync(id);
            if (ytask == null)
            {
                return HttpNotFound();
            }
            return View(ytask);
        }

        // POST: /Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            YTask ytask = await db.Tasks.FindAsync(id);
            db.Tasks.Remove(ytask);
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
