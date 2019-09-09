using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicationDashboardMVC.Models
{
    public class ProductsViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPriceProduct { get; set; }
        public int UnitsInStock { get; set; }
        public string ProductImage { get; set; }
        public string ProductType { get; set; }
        public int QteSelected { get; set; }

    }

    public class ProductOrCustomerViewModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string TypeOrCountry { get; set; }
        public string Type { get; set; }
    }

    public class DailyPredictiveViewModel
    {
        public string ItemName { get; set; }
        public int ItemID { get; set; }
        public string AmountSpend { get; set; }
        public string Suggestion { get; set; }
        public string ItemImage { get; internal set; }
        public string ItemCategory { get; internal set; }
    }
}