using DXWebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DXWebApplication1.Controllers
{
    public class TreeListTestController : Controller
    {
        // GET: TreeListTest
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TreeListControl()
        {
            var model = TreeListModel.GetTreeListData();
            return PartialView(model);
        }

        public ActionResult Custom(string filter = "")
        {
            ViewData["search"] = filter.ToLower();
            return PartialView("TreeListControl", TreeListModel.GetTreeListData());
        }

    }
}