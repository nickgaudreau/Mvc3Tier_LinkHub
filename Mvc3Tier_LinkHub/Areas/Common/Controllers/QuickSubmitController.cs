using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;

namespace Mvc3Tier_LinkHub.Areas.Common.Controllers
{
    public class QuickSubmitController : BaseCommonController
    {
        // GET: Common/QuickSubmit
        public ActionResult Index()
        {
            ViewBag.CategoryId = new SelectList(_objBl.categoryBl.GetAll().ToList(), "i_CategoryId", "c_CategoryName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(QuickSubmit quickSubmit)
        {
            try
            {
                // set default to 'P'ending
                quickSubmit.Url.c_IsApproved = "P";

                // Need to Create a user...

                if (ModelState.IsValid)
                {
                    // also need to insert user
                    _objBl.urlBl.Insert(quickSubmit.Url);
                    TempData["Msg"] = "Created Successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CategoryId = new SelectList(_objBl.categoryBl.GetAll().ToList(), "i_CategoryId", "c_CategoryName");
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