using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace Mvc3Tier_LinkHub.Areas.Admin.Controllers
{
    public class BaseAdminController : Controller
    {
        protected readonly AdminBl _objBl;

        // Constructor instantiate every time we call Controller
        public BaseAdminController()
        {
            _objBl = new AdminBl();
        }
    }
}