using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DXWebApplication1.Models;

namespace DXWebApplication1.Controllers
{
    public class PopupNewController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var list = Users.GetUsers();

            Book book = new Book { Id = 0, Name = "", ISBN = "" };
            return View(new UserBookModel { listUsers = list, Book = book });
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var listeUzak = Request.Params["liste"];

            var list = Users.GetUsers();

            Book book = new Book { Id = 0, Name = "", ISBN = "" };


            return PartialView("_GridViewPartial", new UserBookModel {listUsers=list,Book=book  });
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew(DXWebApplication1.Models.User item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate(DXWebApplication1.Models.User item)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                    ViewData["Users"] = item;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", Users.GetUsers());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(System.Int32 Id)
        {
            var model = new object[0];
            if (Id >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewPartial", model);
        }
    }
}