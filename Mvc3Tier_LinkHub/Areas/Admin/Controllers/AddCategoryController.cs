using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;

namespace Mvc3Tier_LinkHub.Areas.Admin.Controllers
{
    public class AddCategoryController : BaseAdminController
    {

        // GET: Admin/AddCategory
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(tbl_Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _objBl.categoryBl.Insert(category);
                    TempData["Msg"] = "Created Successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Insertion Fail: " + e1.Message + " Error relate to: " + e1.Source;
                return RedirectToAction("Index");
            }
        }
    }
}