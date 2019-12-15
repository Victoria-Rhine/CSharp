using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheFinalBattle.DAL;
using TheFinalBattle.Models;

namespace TheFinalBattle.Controllers
{
    public class RSVPsController : Controller
    {
        private FinalContext db = new FinalContext();

        // GET: RSVPs
        public ActionResult Index()
        {
            var rSVPs = db.RSVPs.Include(r => r.Event).Include(r => r.Person);
            return View(rSVPs.ToList());
        }

        // GET: RSVPs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSVP rSVP = db.RSVPs.Find(id);
            if (rSVP == null)
            {
                return HttpNotFound();
            }
            return View(rSVP);
        }

        // GET: RSVPs/Create
        public ActionResult Create()
        {
            ViewBag.EventID = new SelectList(db.Events, "ID", "Title");
            ViewBag.PersonID = new SelectList(db.Persons, "ID", "Name");
            return View();
        }

        // POST: RSVPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //  public ActionResult Create([Bind(Include = "ID,Timestamp,EventID,PersonID")] RSVP rSVP)
        // {
          public ActionResult Create([Bind(Include = "ID,EventID,PersonID")] RSVP rSVP)
         {
           rSVP.Timestamp = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.RSVPs.Add(rSVP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventID = new SelectList(db.Events, "ID", "Title", rSVP.EventID);
            ViewBag.PersonID = new SelectList(db.Persons, "ID", "Name", rSVP.PersonID);
            return View(rSVP);
        }

        // GET: RSVPs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSVP rSVP = db.RSVPs.Find(id);
            if (rSVP == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventID = new SelectList(db.Events, "ID", "Title", rSVP.EventID);
            ViewBag.PersonID = new SelectList(db.Persons, "ID", "Name", rSVP.PersonID);
            return View(rSVP);
        }

        // POST: RSVPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Timestamp,EventID,PersonID")] RSVP rSVP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rSVP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventID = new SelectList(db.Events, "ID", "Title", rSVP.EventID);
            ViewBag.PersonID = new SelectList(db.Persons, "ID", "Name", rSVP.PersonID);
            return View(rSVP);
        }

        // GET: RSVPs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSVP rSVP = db.RSVPs.Find(id);
            if (rSVP == null)
            {
                return HttpNotFound();
            }
            return View(rSVP);
        }

        // POST: RSVPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RSVP rSVP = db.RSVPs.Find(id);
            db.RSVPs.Remove(rSVP);
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
