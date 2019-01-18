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
    public class ShowTimeController : Controller
    {
        private DatabaseContex db = new DatabaseContex();

        // GET: ShowTime
        public ActionResult Index()
        {
            var showTimes = db.ShowTimes.Include(s => s.Cinema).Include(s => s.Hall);
            return View(showTimes.ToList());
        }

        // GET: ShowTime/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShowTime showTime = db.ShowTimes.Find(id);
            if (showTime == null)
            {
                return HttpNotFound();
            }
            return View(showTime);
        }

        // GET: ShowTime/Create
        public ActionResult Create()
        {
            ViewBag.CinemaId = new SelectList(db.Cinemas, "Id", "Name");
            ViewBag.HallId = new SelectList(db.Halls, "Id", "Name");
            return View();
        }

        // POST: ShowTime/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CinemaId,Date,StartTime,EndTime,HallId")] ShowTime showTime)
        {
            if (ModelState.IsValid)
            {
                db.ShowTimes.Add(showTime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CinemaId = new SelectList(db.Cinemas, "Id", "Name", showTime.CinemaId);
            ViewBag.HallId = new SelectList(db.Halls, "Id", "Name", showTime.HallId);
            return View(showTime);
        }

        // GET: ShowTime/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShowTime showTime = db.ShowTimes.Find(id);
            if (showTime == null)
            {
                return HttpNotFound();
            }
            ViewBag.CinemaId = new SelectList(db.Cinemas, "Id", "Name", showTime.CinemaId);
            ViewBag.HallId = new SelectList(db.Halls, "Id", "Name", showTime.HallId);
            return View(showTime);
        }

        // POST: ShowTime/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CinemaId,Date,StartTime,EndTime,HallId")] ShowTime showTime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(showTime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CinemaId = new SelectList(db.Cinemas, "Id", "Name", showTime.CinemaId);
            ViewBag.HallId = new SelectList(db.Halls, "Id", "Name", showTime.HallId);
            return View(showTime);
        }

        // GET: ShowTime/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShowTime showTime = db.ShowTimes.Find(id);
            if (showTime == null)
            {
                return HttpNotFound();
            }
            return View(showTime);
        }

        // POST: ShowTime/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShowTime showTime = db.ShowTimes.Find(id);
            db.ShowTimes.Remove(showTime);
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
