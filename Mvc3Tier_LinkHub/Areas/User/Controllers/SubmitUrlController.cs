using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;

namespace Mvc3Tier_LinkHub.Areas.User.Controllers
{
    public class SubmitUrlController : Controller
    {
        //private CategoryBl _objBlCat;
        //private UserBl _objBlUser;
        //private UrlBl _objBlUrl;
        private readonly UserAreaBl _objBl;


        // Constructor instantiate every time we call Controller
        public SubmitUrlController()
        {
            _objBl = new UserAreaBl();
            //_objBlCat = new CategoryBl();
            //_objBlUser = new UserBl();
            //_objBlUrl = new UrlBl();
        }

        // GET: User/SubmitUrl
        public ActionResult Index()
        {
            // Fill our dropdownlist with id value, and name as text
            ViewBag.CategoryId = new SelectList(_objBl.categoryBl.GetAll().ToList(), "i_CategoryId", "c_CategoryName");
            ViewBag.UserId = new SelectList(_objBl.userBl.GetAll().ToList(), "i_UserId", "c_UserEmail");
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Url url)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _objBl.urlBl.Insert(url);
                    TempData["Msg"] = "Created Successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CategoryId = new SelectList(_objBl.categoryBl.GetAll().ToList(), "i_CategoryId", "c_CategoryName");
                    ViewBag.UserId = new SelectList(_objBl.userBl.GetAll().ToList(), "i_UserId", "c_UserEmail");
                    return View("Index");
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Insertion Fail: " + e1.Message + " Error relate to: " + e1.Source;
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}