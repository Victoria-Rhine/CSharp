/* This controller handles operations for Requirement #2. 
 * Auto generated Results controller stripped of unnecessary CRUD and repurposed to populate custom view model */

using System.Linq;
using System.Web.Mvc;
using SportsSite.Models;
using SportsSite.Models.DAL;
using SportsSite.Models.ViewModels;

namespace SportsSite.Controllers
{
    public class IndResultsController : Controller
    {
        private SportsContext db = new SportsContext();

        public ActionResult Index(Result result)
        {
            // Query the db to match chose AID and populate view model for individual results
            var athleteResults = db.Events
                .Join(db.Results.Where(r => r.AID == result.AID),
                e => e.ID,
                r => r.EID,
                (e, r) => new { e, r })
                .Join(db.LocationDetails,
                er => er.r.LID,
                l => l.ID,
                (er, l) => new { er, l })
                .Select(m => new IndResultsModel
                {
                    EventName = m.er.e.Type,
                    EventDate = m.l.Date,
                    EventLocation = m.l.Place,
                    AthleteResult = m.er.r.RaceTime
                }).ToList();

            // Order them by date so results are displayed nice
            var dates = from d in athleteResults select d;
            dates = dates.OrderByDescending(d => d.EventDate);
            // Grab the athlete name so we can use it in the view and make things look pretty
            var athleteName = (from a in db.Athletes where a.ID == result.AID select a.Name).FirstOrDefault();
            ViewBag.AthleteName = athleteName;

            return View(dates.ToList());
        }

        // GET: IndResults/Create
        public ActionResult Create()
        {
            ViewBag.AID = new SelectList(db.Athletes, "ID", "Name");
            return View();
        }

        // POST: IndResults/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Result result)
        {
            ViewBag.AID = new SelectList(db.Athletes, "ID", "Name", result.AID);
            return RedirectToAction("Index", result);
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
