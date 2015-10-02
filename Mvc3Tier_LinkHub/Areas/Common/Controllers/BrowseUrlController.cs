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
        public ActionResult Index(string sortOrder, string sortBy)
        {
            ViewBag.SortOrder = sortOrder; // we pass this so the opposite sorting is pass into the Query string when clicked again
            ViewBag.SortBy = sortBy;
            var urls = objBl.GetAll().Where(x => x.c_IsApproved == "A");

            switch (sortBy)
            {
                case "Title":
                    switch (sortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.c_UrlTitle).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.c_UrlTitle).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "Url":
                    switch (sortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.c_Url).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.c_Url).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "Description":
                    switch (sortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.c_UrlDesc).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.c_UrlDesc).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "Category":
                    switch (sortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.tbl_Category.c_CategoryName).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.tbl_Category.c_CategoryName).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    urls = urls.OrderByDescending(x => x.c_UrlTitle).ToList();
                    break;

            }


            return View(urls);
        }
    }
}