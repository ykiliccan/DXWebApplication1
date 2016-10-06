using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DXWebApplication1.Controllers
{
    public class TabPageTestController : Controller
    {
        // GET: TabPageTest
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OnCallback()
        {
            object test = Request.Params["tabIndex"];

            return PartialView("PageControl");
        }
    }
}