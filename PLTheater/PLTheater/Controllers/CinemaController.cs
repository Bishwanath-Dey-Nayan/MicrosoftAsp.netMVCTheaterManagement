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
    public class CinemaController : Controller
    {
        private DatabaseContex db = new DatabaseContex();

        // GET: Cinema
        public ActionResult Index()
        {
            var cinemas = db.Cinemas.Include(c => c.Category).Include(c => c.Genre).Include(c => c.Producer);
            return View(cinemas.ToList());
        }

        public ActionResult All()
        {
            var cinemas = db.Cinemas.ToList();
            return View(cinemas);
        }

        public ActionResult Category()
        {
            var categories = db.Categories.ToList();
            return View(categories);
        }

        public ActionResult Casting()
        {
            var castings = db.Castings.ToList();
            return View(castings);
        }

        public ActionResult View(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinema cinema = db.Cinemas.Find(id);
            if (cinema == null)
            {
                return HttpNotFound();
            }
            return View(cinema);
        }

        // GET: Cinema/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinema cinema = db.Cinemas.Find(id);
            if (cinema == null)
            {
                return HttpNotFound();
            }
            return View(cinema);
        }

        // GET: Cinema/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name");
            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name");
            return View();
        }

        // POST: Cinema/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Name,GenreId,CategoryId,Duration,Description,TrailerLink,ProducerId,IMDBLink")] Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                db.Cinemas.Add(cinema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", cinema.CategoryId);
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", cinema.GenreId);
            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name", cinema.ProducerId);
            return View(cinema);
        }

        // GET: Cinema/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinema cinema = db.Cinemas.Find(id);
            if (cinema == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", cinema.CategoryId);
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", cinema.GenreId);
            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name", cinema.ProducerId);
            return View(cinema);
        }

        // POST: Cinema/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,GenreId,CategoryId,Duration,Description,TrailerLink,ProducerId,IMDBLink")] Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cinema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", cinema.CategoryId);
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", cinema.GenreId);
            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name", cinema.ProducerId);
            return View(cinema);
        }

        // GET: Cinema/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinema cinema = db.Cinemas.Find(id);
            if (cinema == null)
            {
                return HttpNotFound();
            }
            return View(cinema);
        }

        // POST: Cinema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cinema cinema = db.Cinemas.Find(id);
            db.Cinemas.Remove(cinema);
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
