/* This controller handles operations for Requirement #3. 
 * Auto generated Athlete controller stripped of unnecessary CRUD and repurposed to populate custom view model */

using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using SportsSite.Models;
using SportsSite.Models.DAL;
using SportsSite.Models.ViewModels;

namespace SportsSite.Controllers
{
    public class GraphController : Controller
    {
        private SportsContext db = new SportsContext();

        // Use chose TID and query db to get athletes on that team and all events
        public ActionResult Index(Athlete athlete)
        {
            var teamAthletes = (from a in db.Athletes where a.TID == athlete.TID select a.Name).Distinct();
            var events = (from e in db.Events select e.Type).Distinct();

            ViewBag.Athletes = teamAthletes;
            ViewBag.Events = events;

            return View();
        }

        // GET: Graph/Create
        public ActionResult Create()
        {
            ViewBag.TID = new SelectList(db.Teams, "ID", "Name");
            return View();
        }

        // POST: Graph/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Athlete athlete)
        {
            ViewBag.TID = new SelectList(db.Teams, "ID", "Name", athlete.TID);
            return RedirectToAction("Index", athlete);
        }

        // Do the math to create the graph 
        public ActionResult GraphMath()
        {
            string athleteName = Request.QueryString["athlete"];
            string eventType = Request.QueryString["event"];

            var graphModel =
                db.Results
                .Join(db.Athletes.Where(a => a.Name == athleteName),
                r => r.AID,
                a => a.ID,
                (r, a) => new { r, a })
                .Join(db.Events.Where(e => e.Type == eventType),
                ra => ra.r.EID,
                e => e.ID,
                (ra, e) => new { ra, e })
                .Join(db.LocationDetails,
                rae => rae.ra.r.LID,
                l => l.ID,
                (rae, l) => new { rae, l})
                .Select(m => new GraphModel
                {
                    EventName = m.rae.e.Type,
                    EventDate = m.l.Date,
                    RaceResult = m.rae.ra.r.RaceTime
                }
                ).ToList();

            // Sort by dates
            var dates = from d in graphModel select d;
            dates = dates.OrderByDescending(d => d.EventDate);

            string jsonString = JsonConvert.SerializeObject(dates, Formatting.Indented);
            return new ContentResult
            {
                Content = jsonString,
                ContentType = "application/json",
                ContentEncoding = System.Text.Encoding.UTF8
            };
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
