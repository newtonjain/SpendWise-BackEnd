using ApplicationDashboardMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpendWise.AI.Controllers
{
    public class SuggestionController : Controller
    {
        public ActionResult Suggestion()
        {
            return View();
        }

        public ActionResult GetDetails(string type)
        {          

            return PartialView("~/Views/Dashboard/GetDetails.cshtml", null);

        }

    }
}