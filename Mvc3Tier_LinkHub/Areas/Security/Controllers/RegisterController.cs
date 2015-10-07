using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;

namespace Mvc3Tier_LinkHub.Areas.Security.Controllers
{
    public class RegisterController : BaseSecurityController
    {
        // GET: Security/Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_User user) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user.c_Role = "U";
                    _objBl.userBl.Insert(user);
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
                TempData["Msg"] = "Fail to create new user: " + e1.Message + " Error relate to: " + e1.Source;
                return RedirectToAction("Index");
            }
        }
    }
}