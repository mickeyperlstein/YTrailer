using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YTrailerWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult DoubleValue(int Value)
        {
            if (!Request.IsAjaxRequest())
            {
                //no ajax
                return null;
            }else
            {
                int ret = Value * 2;
                return new JsonResult { Data = new { DoubleValue = ret } };
            }
        }

        public ActionResult TaskAPI() 
        { 
            return View();
        }
    }
}