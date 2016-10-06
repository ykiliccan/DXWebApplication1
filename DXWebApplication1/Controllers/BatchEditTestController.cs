using DXWebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DXWebApplication1.Controllers
{
    public class BatchEditTestController : Controller
    {
        // GET: BatchEditTest
        public ActionResult Index()
        {
            var listParam = ParametreSample.ParametreleriOlustur();
            return View(/*"_GridViewPartial",*/listParam);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var listParam = ParametreSample.ParametreleriOlustur();

            return PartialView("_GridViewPartial", listParam);
        }
    }
}