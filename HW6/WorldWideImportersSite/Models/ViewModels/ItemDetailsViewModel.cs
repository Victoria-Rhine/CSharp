using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldWideImportersSite.Models.ViewModels
{

    public class ItemDetailsViewModel
    {
        public ItemDetailsViewModel(StockItem stockItem, Supplier supplier, Person person, InvoiceLine invoiceLine)
        {
            StockItemName = stockItem.StockItemName;
            Size = stockItem.Size;
            RecommendedRetailPrice = stockItem.RecommendedRetailPrice;
            TypicalWeightPerUnit = stockItem.TypicalWeightPerUnit;
            LeadTimeDays = stockItem.LeadTimeDays;
            ValidFrom = stockItem.ValidFrom;
            CustomFields = stockItem.CustomFields;
            Tags = stockItem.Tags;
            Photo = stockItem.Photo;

            SupplierName = supplier.SupplierName;
            PhoneNumber = supplier.PhoneNumber;
            FaxNumber = supplier.FaxNumber;
            WebsiteURL = supplier.WebsiteURL;
            SupplierID = supplier.SupplierID;
            PrimaryContactPersonID = supplier.PrimaryContactPersonID;

            PersonID = person.PersonID;
            FullName = person.FullName;

            Quantity = invoiceLine.Quantity;
        }

        public ItemDetailsViewModel(StockItem stockItem)
        {
            StockItemName = stockItem.StockItemName;
            Size = stockItem.Size;
            RecommendedRetailPrice = stockItem.RecommendedRetailPrice;
            TypicalWeightPerUnit = stockItem.TypicalWeightPerUnit;
            LeadTimeDays = stockItem.LeadTimeDays;
            ValidFrom = stockItem.ValidFrom;
            CustomFields = stockItem.CustomFields;
            Tags = stockItem.Tags;
            Photo = stockItem.Photo;
        }

        public ItemDetailsViewModel(Supplier supplier)
        {
            SupplierName = supplier.SupplierName;
            PhoneNumber = supplier.PhoneNumber;
            FaxNumber = supplier.FaxNumber;
            WebsiteURL = supplier.WebsiteURL;
            SupplierID = supplier.SupplierID;
            PrimaryContactPersonID = supplier.PrimaryContactPersonID;
        }

        public ItemDetailsViewModel(Person person)
        {
            PersonID = person.PersonID;
            FullName = person.FullName;
        }

        public ItemDetailsViewModel(InvoiceLine invoiceLine)
        {
            Quantity = invoiceLine.Quantity;
            
        }

        // all the things we need for stock items
        public string StockItemName { get; set; }
        public string Size { get; set; }
        public decimal? RecommendedRetailPrice { get; set; }
        public decimal TypicalWeightPerUnit { get; set; }
        public int LeadTimeDays { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ValidFrom { get; set; }
        public string CustomFields { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string Tags { get; set; }
        public byte[] Photo { get; set; }

        // all the things we need for the supplier
        public string SupplierName { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string WebsiteURL { get; set; }
        public int SupplierID { get; set; }
        public int PrimaryContactPersonID { get; set; }


        // all the things we need for the person
        public int PersonID { get; set; }
        public string FullName { get; set; }

        //purchase history information
        public double Quantity { get; set; }

        public double Ind_Order { get; set; }

        public decimal GrossSales { get; set; }
        public decimal GrossProfit { get; set; }

        //for the purchase list
        public List<PurchaseList> ListOfPurchases { get; set; }
    }

    public class PurchaseList
    {
        //purchase list
        public string CustomerName { get; set; }
        public int Quantity { get; set; }
    }
}