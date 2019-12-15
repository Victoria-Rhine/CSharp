/* This controller adds a new result to the db. 
 * Auto generated Results controller stripped of unnecessary */

using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SportsSite.Models;
using SportsSite.Models.DAL;

namespace SportsSite.Controllers
{
    public class ResultsController : Controller
    {
        private SportsContext db = new SportsContext();

        // GET: Results
        public ActionResult Index()
        {
            var results = db.Results.Include(r => r.Athlete).Include(r => r.Event).Include(r => r.LocationDetail);
            return View(results.ToList());
        }

        // GET: Results/Create
        public ActionResult Create()
        {
            ViewBag.AID = new SelectList(db.Athletes, "ID", "Name");
            ViewBag.EID = new SelectList(db.Events, "ID", "Type");
            ViewBag.LID = new SelectList(db.LocationDetails, "ID", "Place");
            return View();
        }

        // POST: Results/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RaceTime,AID,EID,LID")] Result result)
        {
            if (ModelState.IsValid)
            {
                db.Results.Add(result);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AID = new SelectList(db.Athletes, "ID", "Name", result.AID);
            ViewBag.EID = new SelectList(db.Events, "ID", "Type", result.EID);
            ViewBag.LID = new SelectList(db.LocationDetails, "ID", "Place", result.LID);
            return View(result);
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
