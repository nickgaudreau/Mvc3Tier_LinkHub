using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;
using System.Web.Security;

namespace Mvc3Tier_LinkHub.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class LoginController : BaseSecurityController
    {
        // GET: Security/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(tbl_User user)
        {
            try
            {
                // validate user
                if (Membership.ValidateUser(user.c_UserEmail, user.c_Password))
                {
                    FormsAuthentication.SetAuthCookie(user.c_UserEmail, false);
                    return RedirectToAction("Index", "Home", new { area = "Common" });
                }
                else
                {
                    TempData["Msg"] = "Login Failure - make sure right user/password combination!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Failed: " + e1.Message + " Error relate to: " + e1.Source;
                return RedirectToAction("Index");
            }
        }


        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "Common" });
        }


    }
}