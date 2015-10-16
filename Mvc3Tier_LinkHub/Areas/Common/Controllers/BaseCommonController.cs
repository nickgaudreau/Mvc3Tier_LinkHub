using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace Mvc3Tier_LinkHub.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class BaseCommonController : Controller
    {
        protected readonly CommonBl _objBl;

        // Constructor instantiate every time we call Controller
        public BaseCommonController()
        {
            _objBl = new CommonBl();
        }
    }
}