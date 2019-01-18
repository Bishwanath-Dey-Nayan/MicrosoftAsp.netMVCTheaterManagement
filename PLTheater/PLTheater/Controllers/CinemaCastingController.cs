using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PLTheater.Models;

namespace PLTheater.Controllers
{
    public class CinemaCastingController : Controller
    {
        private DatabaseContex db = new DatabaseContex();

        // GET: CinemaCasting
        public ActionResult Index()
        {
            var cinemaCastings = db.CinemaCastings.Include(c => c.Casting).Include(c => c.Cinema);
            return View(cinemaCastings.ToList());
        }

        // GET: CinemaCasting/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CinemaCasting cinemaCasting = db.CinemaCastings.Find(id);
            if (cinemaCasting == null)
            {
                return HttpNotFound();
            }
            return View(cinemaCasting);
        }

        // GET: CinemaCasting/Create
        public ActionResult Create()
        {
            ViewBag.CastingId = new SelectList(db.Castings, "Id", "Name");
            ViewBag.CinemaId = new SelectList(db.Cinemas, "Id", "Name");
            return View();
        }

        // POST: CinemaCasting/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CinemaId,CastingId,Description")] CinemaCasting cinemaCasting)
        {
            if (ModelState.IsValid)
            {
                db.CinemaCastings.Add(cinemaCasting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CastingId = new SelectList(db.Castings, "Id", "Name", cinemaCasting.CastingId);
            ViewBag.CinemaId = new SelectList(db.Cinemas, "Id", "Name", cinemaCasting.CinemaId);
            return View(cinemaCasting);
        }

        // GET: CinemaCasting/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CinemaCasting cinemaCasting = db.CinemaCastings.Find(id);
            if (cinemaCasting == null)
            {
                return HttpNotFound();
            }
            ViewBag.CastingId = new SelectList(db.Castings, "Id", "Name", cinemaCasting.CastingId);
            ViewBag.CinemaId = new SelectList(db.Cinemas, "Id", "Name", cinemaCasting.CinemaId);
            return View(cinemaCasting);
        }

        // POST: CinemaCasting/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CinemaId,CastingId,Description")] CinemaCasting cinemaCasting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cinemaCasting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CastingId = new SelectList(db.Castings, "Id", "Name", cinemaCasting.CastingId);
            ViewBag.CinemaId = new SelectList(db.Cinemas, "Id", "Name", cinemaCasting.CinemaId);
            return View(cinemaCasting);
        }

        // GET: CinemaCasting/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CinemaCasting cinemaCasting = db.CinemaCastings.Find(id);
            if (cinemaCasting == null)
            {
                return HttpNotFound();
            }
            return View(cinemaCasting);
        }

        // POST: CinemaCasting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CinemaCasting cinemaCasting = db.CinemaCastings.Find(id);
            db.CinemaCastings.Remove(cinemaCasting);
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
