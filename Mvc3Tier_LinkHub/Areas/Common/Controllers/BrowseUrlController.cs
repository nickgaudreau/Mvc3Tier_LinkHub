using System;
using System.Linq;
using System.Web.Mvc;
using BLL;

namespace Mvc3Tier_LinkHub.Areas.Common.Controllers
{
    public class BrowseUrlController : Controller
    {

        private readonly UrlBl _objBl;

        // Constructor instantiate every time we call Controller
        public BrowseUrlController()
        {
            _objBl = new UrlBl();
        }


        // GET: Common/BrowseUrl
        public ActionResult Index(string sortOrder, string sortBy, string page)
        {
            ViewBag.SortOrder = sortOrder; // we pass this so the opposite sorting is pass into the Query string when clicked again
            ViewBag.SortBy = sortBy;
            var urls = _objBl.GetAll().Where(x => x.c_IsApproved == "A");

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

            // Find page count. If 10 records per page and we have 37 records then it is 4 pages
            ViewBag.TotalPages = Math.Ceiling(_objBl.GetAll().Count(x => x.c_IsApproved == "A") /10.0 );

            int currentPage = int.Parse(page == null ? "1" : page);

            ViewBag.Page = currentPage; // to know which page to highlight even when we sort, and in the query string

            // take the current page - 1 and mutli by 10 to give a start point in the data, then take next 10 records to display
            urls = urls.Skip((currentPage - 1) * 10).Take(10);

            return View(urls);
        }
    }
}