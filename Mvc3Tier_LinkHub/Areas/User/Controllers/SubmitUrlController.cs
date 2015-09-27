using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;

namespace Mvc3Tier_LinkHub.Areas.User.Controllers
{
    public class SubmitUrlController : Controller
    {
        // GET: User/SubmitUrl
        public ActionResult Index()
        {
            Mvc3TierEntities dbEntities = new Mvc3TierEntities();
            // Fill our dropdownlist with id value, and name as text
            ViewBag.CategoryId = new SelectList(dbEntities.tbl_Category, "i_CategoryId", "c_CategoryName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Url url)
        {
            Mvc3TierEntities dbEntities = new Mvc3TierEntities();
            return View();
        }

    }
}