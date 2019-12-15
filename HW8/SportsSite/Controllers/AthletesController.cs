/* This controller adds a new athlete to the db. Auto generated controller stripped of unnecessary CRUD */

using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SportsSite.Models;
using SportsSite.Models.DAL;

namespace SportsSite.Controllers
{
    public class AthletesController : Controller
    {
        private SportsContext db = new SportsContext();

        // GET: Athletes
        public ActionResult Index()
        {
            var athletes = db.Athletes.Include(a => a.Team);
            return View(athletes.ToList());
        }

        // GET: Athletes/Create
        public ActionResult Create()
        {
            ViewBag.TID = new SelectList(db.Teams, "ID", "Name");
            return View();
        }

        // POST: Athletes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Gender,TID")] Athlete athlete)
        {
            if (ModelState.IsValid)
            {
                db.Athletes.Add(athlete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TID = new SelectList(db.Teams, "ID", "Name", athlete.TID);
            return View(athlete);
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
