using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _12246765_OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Assignment 2 for Web Development Summer Semester 2020";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Axel Baylon";

            return View();
        }
    }
}