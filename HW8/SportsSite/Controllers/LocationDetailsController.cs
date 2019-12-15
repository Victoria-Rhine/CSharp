/* This controller adds a new location to the db. 
 * Auto generated LocationDetails controller stripped of unnecessary */

using System.Linq;
using System.Web.Mvc;
using SportsSite.Models;
using SportsSite.Models.DAL;

namespace SportsSite.Controllers
{
    public class LocationDetailsController : Controller
    {
        private SportsContext db = new SportsContext();

        // GET: LocationDetails
        public ActionResult Index()
        {
            return View(db.LocationDetails.ToList());
        }

        // GET: LocationDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocationDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date,Place")] LocationDetail locationDetail)
        {
            if (ModelState.IsValid)
            {
                db.LocationDetails.Add(locationDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(locationDetail);
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
