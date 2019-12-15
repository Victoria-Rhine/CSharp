using System;
using System.Linq;
using System.Web.Mvc;
using WorldWideImportersSite.DAL;
using WorldWideImportersSite.Models;
using WorldWideImportersSite.Models.ViewModels;

namespace WorldWideImportersSite.Controllers
{
    public class ItemController : Controller
    {
        private WWContext db = new WWContext();

        // GET: Item
        [HttpGet]
        public ActionResult Index(string search)
        {
            return View(db.StockItems.Where(x => x.StockItemName.Contains(search)).ToList());
        }

        // GET: Details
        [HttpGet]
        public ActionResult Details(string itemMatch)
        {
            // stock items 
            var itemDetails = (
                from s in db.StockItems
                where s.StockItemName == itemMatch
                select s.StockItemID).FirstOrDefault();

            StockItem stockitem = db.StockItems.Find((int)itemDetails);

            // supplier details
            var supDetails = (
                from s in db.StockItems
                join sp in db.Suppliers
                on s.SupplierID equals sp.SupplierID
                where s.StockItemName == itemMatch
                select sp.SupplierID).FirstOrDefault();

            Supplier supplier = db.Suppliers.Find((int)supDetails);

            // person details
            var personDetails = (
                 from s in db.StockItems
                 join sp in db.Suppliers
                 on s.SupplierID equals sp.SupplierID
                 where s.StockItemName == itemMatch
                 join p in db.People
                 on sp.PrimaryContactPersonID equals p.PersonID
                 select p.PersonID).FirstOrDefault();

            Person person = db.People.Find((int)personDetails);

            // order details
            IQueryable<int> orderDetails = (
                from s in db.StockItems
                join i in db.InvoiceLines
                on s.StockItemID equals i.StockItemID
                where s.StockItemName == itemMatch
                select i.Quantity);

            double count = 0;

            foreach(var quant in orderDetails)
            {
                count += quant;
            }

            InvoiceLine invoiceLine = new InvoiceLine { Quantity = Convert.ToInt32(count) };

            ItemDetailsViewModel viewModel = new ItemDetailsViewModel(stockitem, supplier, person, invoiceLine);


            return View(viewModel);
        }
    }
}