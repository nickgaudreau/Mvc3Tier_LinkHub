using System;
using System.Collections.Generic;
using System.IdentityModel.Services;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;
using System.Web.Security;
using Microsoft.Web.WebPages.OAuth;

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
            FormsAuthentication.SignOut(); // Our custom login
            FederatedAuthentication.SessionAuthenticationModule.SignOut(); // For Auth0
            return RedirectToAction("Index", "Home", new { area = "Common" });
        }

        // For FB .. gooogle failed no open id anymore
        public ActionResult ExternalLogin(string provider)
        {
            OAuthWebSecurity.RequestAuthentication(provider, Url.Action("ExternalLoginCallBack"));
            return RedirectToAction("Index", "Home", new { area = "Common" });
        }

        public ActionResult ExternalLoginCallBack()
        {
            return RedirectToAction("Index", "Home", new { area = "Common" });
        }
    }
}