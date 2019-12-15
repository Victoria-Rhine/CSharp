using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TheFinalBattle.DAL;
using TheFinalBattle.Models;

namespace TheFinalBattle.Controllers
{
    public class EventsController : Controller
    {
        private FinalContext db = new FinalContext();

        public ActionResult RSVPNumbers()
        {
            string myEvent = Request.QueryString["event"];

            var eventID = (from a in db.Events where a.Title == myEvent select a.ID);

            var results = db.RSVPs.Join(db.Events.Where(e => e.Title == myEvent),
                r => r.EventID, e => e.ID, (r, e) => new { r, e }).Select(r => r.e.ID).ToList();

            // make a list of the results
            List<RSVP> resultsList = new List<RSVP>();

            for (int i = 0; i < results.Count; i++)
            {
                resultsList.Add(new RSVP
                {
                    EventID = results.ElementAt(i)
                });
            }

            // this is where the json magic happens
            string jsonString = JsonConvert.SerializeObject(resultsList, Formatting.Indented);
            return new ContentResult
            {
                Content = jsonString,
                ContentType = "application/json",
                ContentEncoding = System.Text.Encoding.UTF8
            };

        }

        // GET: Events
        public ActionResult Index()
        {
            var events = db.Events.Include(e => e.Person);
            return View(events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.PersonID = new SelectList(db.Persons, "ID", "Name");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Start,Duration,Location,PersonID")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonID = new SelectList(db.Persons, "ID", "Name", @event.PersonID);
            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonID = new SelectList(db.Persons, "ID", "Name", @event.PersonID);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Start,Duration,Location,PersonID")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonID = new SelectList(db.Persons, "ID", "Name", @event.PersonID);
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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
