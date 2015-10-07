using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace Mvc3Tier_LinkHub.Areas.Security.Controllers
{
    public class BaseSecurityController : Controller
    {
        protected readonly UserAreaBl _objBl;

        // Constructor instantiate every time we call Controller
        public BaseSecurityController()
        {
            _objBl = new UserAreaBl();
        }
    }
}