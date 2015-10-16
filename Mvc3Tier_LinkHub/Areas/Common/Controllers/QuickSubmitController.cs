using System;
using System.Linq;
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
                ModelState.Remove("User.c_Password");
                ModelState.Remove("User.c_ConfirmPassword");
                ModelState.Remove("Url.c_UrlDesc");
                if (ModelState.IsValid)
                {
                    _objBl.InsertQuickSubmit(quickSubmit);
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