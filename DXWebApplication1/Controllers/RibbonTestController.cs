using DXWebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DXWebApplication1.Controllers
{
    public class RibbonTestController : Controller
    {
        // GET: RibbonTest
        public ActionResult Index()
        {
            return RedirectToAction("Features", new RibbonFeaturesDemoOptions());
        }

        public ActionResult Features()
        {
            return View("Features", new RibbonFeaturesDemoOptions());
        }
        [HttpPost]
        public ActionResult Features(RibbonFeaturesDemoOptions options)
        {
            return View("Features", options);
        }
    }
}