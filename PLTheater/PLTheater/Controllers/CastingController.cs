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
    public class CastingController : Controller
    {
        private DatabaseContex db = new DatabaseContex();

        // GET: Casting
        public ActionResult Index()
        {
            var castings = db.Castings.Include(c => c.Gender);
            return View(castings.ToList());
        }

        // GET: Casting/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casting casting = db.Castings.Find(id);
            if (casting == null)
            {
                return HttpNotFound();
            }
            return View(casting);
        }

        // GET: Casting/Create
        public ActionResult Create()
        {
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name");
            return View();
        }

        // POST: Casting/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,GenderId")] Casting casting)
        {
            if (ModelState.IsValid)
            {
                db.Castings.Add(casting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name", casting.GenderId);
            return View(casting);
        }

        // GET: Casting/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casting casting = db.Castings.Find(id);
            if (casting == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name", casting.GenderId);
            return View(casting);
        }

        // POST: Casting/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,GenderId")] Casting casting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(casting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name", casting.GenderId);
            return View(casting);
        }

        // GET: Casting/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casting casting = db.Castings.Find(id);
            if (casting == null)
            {
                return HttpNotFound();
            }
            return View(casting);
        }

        // POST: Casting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Casting casting = db.Castings.Find(id);
            db.Castings.Remove(casting);
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
