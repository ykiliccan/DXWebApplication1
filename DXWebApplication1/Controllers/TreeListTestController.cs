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
        public ActionResult TreeListControl(string search, string filter, string columnList,string filterMode)
        {
            //ViewData["search"] = search == null ? null : search.ToLower();

            // var model = TreeListModel.GetTreeListData();
            var model = GetData(search, filter, columnList,filterMode);

            return PartialView(model);
        }

        public ActionResult Custom(string search, string filter,string columnList, string filterMode)
        {

            var model = GetData(search, filter, columnList,filterMode);
            return PartialView("TreeListControl", model);
        }

        public List<TreeListModel> GetData(string search,string filter,string columnList, string filterMode)
        {
            ViewData["search"] = search == null ? null : search.ToLower();
            ViewData["filter"] = filter == null ? null : filter.ToLower();
            ViewData["columnList"] = columnList == null ? null : columnList.ToLower();

            List<TreeListModel> model = null;
            if (!string.IsNullOrWhiteSpace(filter))
            {
                model = TreeListModel.GetTreeListDataWithFilter(filter, columnList,filterMode);
            }
            else
            {
                model = TreeListModel.GetTreeListData();
            }

            return model;
        }

    }
}