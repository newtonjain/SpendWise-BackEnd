using ApplicationDashboardMVC.DataAccess;
using ApplicationDashboardMVC.Models;
using SpendWise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplicationDashboardMVC.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            var predictiveSavings = SpendWiseServiceUtil.GetPredictiveSavings();
            ViewBag.SpendWiseExpense = "$" + predictiveSavings.Replace('"',' ');            
            return View();

            // using (DashboardContext _context = new DashboardContext())
            // {
            //     ViewBag.CountCustomers = _context.CustomerSet.Count();
            //     ViewBag.MonthlyExpense = "$678";
            //     ViewBag.SpendWiseExpense = "$345";
            // }

            //return View();

            return null;
        }

        public ActionResult GetDetails(string type)
        {
            List<ProductOrCustomerViewModel> result = GetProductOrCustomer(type);

            return PartialView("~/Views/Dashboard/GetDetails.cshtml", result);

        }


        public ActionResult DailyPredictiveExpense()
        {
            //List<DailyPredictiveViewModel> topFiveCustomers = null;


            //var predictiveSavings = SpendWiseServiceUtil.GetDailyPredictiveItems();


            //using (DashboardContext _context = new DashboardContext())
            //{
            //    //var OrderByCustomer = (from o in _context.ProductSet
            //    //                      group o by o.Customer.ID into g
            //    //                      orderby g.Count() descending
            //    //                      select new
            //    //                      {
            //    //                         CustomerID = g.Key,
            //    //                         Count = g.Count()
            //    //                      }).Take(5);

            //     topFiveCustomers = (from c in _context.ProductSet
            //                         select new DailyPredictiveViewModel
            //                         {
            //                          ItemName = c.ProductName,
            //                          ItemImage = c.ProductImage,
            //                          ItemCategory = c.ProductType,
            //                          AmountSpend = c.UnitPrice,
            //                          Suggestion = c.ProductName 
            //                         }).ToList();
            //}

            return PartialView("~/Views/Dashboard/TopCustomers.cshtml", SpendWiseServiceUtil.GetDailyPredictiveItems());
        }

        public ActionResult GetPredictiveForecast()
        {
            //DashboardContext _context = new DashboardContext();

            // var ordersByCountry = (from o in _context.OrderSet
            //                           group o by o.Customer.CustomerCountry into g
            //                           orderby g.Count() descending
            //                           select new
            //                           {
            //                               Country = g.Key,
            //                               CountOrders = g.Count()
            //                           }).ToList();

            //return Json(new { result = ordersByCountry }, JsonRequestBehavior.AllowGet);

            var forecast = SpendWiseServiceUtil.GetPredictiveForecast();            
            var monthlyExpense = forecast.Sum(x => Convert.ToInt32(x.Spending)).ToString();
            Session.Add("MonthlyExpense", monthlyExpense);

            return Json(new { result = forecast }, JsonRequestBehavior.AllowGet);
            //return View();

            
        }

        public ActionResult CustomersByCountry()
        {
            DashboardContext _context = new DashboardContext();

            var customerByCountry = (from c in _context.ProductSet
                                   group c by c.ProductType into g
                                   orderby g.Count() descending
                                   select new
                                   {
                                       Country = g.Key,
                                       CountCustomer = g.Count()
                                   }).ToList();

            return Json(new { result = customerByCountry }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult OrdersByCustomer()
        {
            DashboardContext _context = new DashboardContext();
            var ordersByCustomer = (from o in _context.OrderSet
                                    group o by o.Customer.ID into g
                                    select new
                                    {
                                        Name = from c in _context.CustomerSet
                                               where c.ID == g.Key
                                               select c.CustomerName,

                                        CountOrders = g.Count()

                                    }).ToList();


            return Json(new { result = ordersByCustomer }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MonthlyExpense()
        {
            if (Session["MonthlyExpense"] != null)
            {
                return Content("$ " + Session["MonthlyExpense"].ToString());
            }
            else return null;
        }


        public List<ProductOrCustomerViewModel> GetProductOrCustomer(string type)
        {
            List<ProductOrCustomerViewModel> result = null;

            using (DashboardContext _context = new DataAccess.DashboardContext())
            {
                if (!string.IsNullOrEmpty(type))
                {
                    if (type == "customers")
                    {
                        result = _context.CustomerSet.Select(c => new ProductOrCustomerViewModel
                        {
                            Name = c.CustomerName,
                            Image = c.CustomerImage,
                            TypeOrCountry = c.CustomerCountry,
                            Type = "Customers"

                        }).ToList();

                    }
                    else if (type == "products")
                    {
                        result = _context.ProductSet.Select(p => new ProductOrCustomerViewModel
                        {
                            Name = p.ProductName,
                            Image = p.ProductImage,
                            TypeOrCountry = p.ProductType,
                            Type = p.ProductType

                        }).ToList();

                    }
                }

                return result;
            }

        }
    }
}