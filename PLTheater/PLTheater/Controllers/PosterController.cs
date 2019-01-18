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
    public class PosterController : Controller
    {
        private DatabaseContex db = new DatabaseContex();

        // GET: Poster
        public ActionResult Index()
        {
            var posters = db.Posters.Include(p => p.Cinema);
            return View(posters.ToList());
        }

        // GET: Poster/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poster poster = db.Posters.Find(id);
            if (poster == null)
            {
                return HttpNotFound();
            }
            return View(poster);
        }

        // GET: Poster/Create
        public ActionResult Create()
        {
            ViewBag.CinemaId = new SelectList(db.Cinemas, "Id", "Name");
            return View();
        }

        // POST: Poster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CinemaId,Image,Title")] Poster poster, HttpPostedFileBase imageFile)
        {
            poster.Image = System.IO.Path.GetFileName(imageFile.FileName);

            if (ModelState.IsValid)
            {
                db.Posters.Add(poster);
                db.SaveChanges();

                imageFile.SaveAs(Server.MapPath("../Uploads/Posters/" + poster.Id.ToString() + "_" + poster.Image));

                return RedirectToAction("Index");
            }

            ViewBag.CinemaId = new SelectList(db.Cinemas, "Id", "Name", poster.CinemaId);
            return View(poster);
        }

        // GET: Poster/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poster poster = db.Posters.Find(id);
            if (poster == null)
            {
                return HttpNotFound();
            }
            ViewBag.CinemaId = new SelectList(db.Cinemas, "Id", "Name", poster.CinemaId);
            return View(poster);
        }

        // POST: Poster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CinemaId,Image,Title")] Poster poster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CinemaId = new SelectList(db.Cinemas, "Id", "Name", poster.CinemaId);
            return View(poster);
        }

        // GET: Poster/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poster poster = db.Posters.Find(id);
            if (poster == null)
            {
                return HttpNotFound();
            }
            return View(poster);
        }

        // POST: Poster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Poster poster = db.Posters.Find(id);
            db.Posters.Remove(poster);
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
