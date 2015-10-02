using System.Linq;
using System.Web.Mvc;
using BLL;

namespace Mvc3Tier_LinkHub.Areas.Common.Controllers
{
    public class BrowseUrlController : Controller
    {

        private UrlBl objBl = new UrlBl();

        // Constructor instantiate every time we call Controller
        public BrowseUrlController()
        {
            objBl = new UrlBl();
        }


        // GET: Common/BrowseUrl
        public ActionResult Index()
        {
            var urls = objBl.GetAll().Where(x => x.c_IsApproved == "A").ToList();
            return View(urls);
        }
    }
}