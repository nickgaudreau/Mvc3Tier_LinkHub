using System;
using System.Linq;
using System.Web.Mvc;
using BLL;

namespace Mvc3Tier_LinkHub.Areas.Admin.Controllers
{
    public class ListCategoryController : Controller
    {
        private readonly CategoryBl _objBl;

        // Constructor instantiate every time we call Controller
        public ListCategoryController()
        {
            _objBl = new CategoryBl();
        }


        // GET: Common/BrowseUrl
        public ActionResult Index(string sortOrder, string sortBy, string page)
        {
            ViewBag.SortOrder = sortOrder; // we pass this so the opposite sorting is pass into the Query string when clicked again
            ViewBag.SortBy = sortBy;
            var categories = _objBl.GetAll();

            switch (sortBy)
            {
                case "CategoryName":
                    switch (sortOrder)
                    {
                        case "Asc":
                            categories = categories.OrderBy(x => x.c_CategoryName).ToList();
                            break;
                        case "Desc":
                            categories = categories.OrderByDescending(x => x.c_CategoryName).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "CategoryDesc":
                    switch (sortOrder)
                    {
                        case "Asc":
                            categories = categories.OrderBy(x => x.c_CategoryDesc).ToList();
                            break;
                        case "Desc":
                            categories = categories.OrderByDescending(x => x.c_CategoryDesc).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                
                default:
                    categories = categories.OrderBy(x => x.c_CategoryName).ToList();
                    break;

            }

            // Find page count. If 10 records per page and we have 37 records then it is 4 pages
            ViewBag.TotalPages = Math.Ceiling(_objBl.GetAll().Count() /10.0 );

            int currentPage = int.Parse(page == null ? "1" : page);

            ViewBag.Page = currentPage; // to know which page to highlight even when we sort, and in the query string

            // take the current page - 1 and mutli by 10 to give a start point in the data, then take next 10 records to display
            categories = categories.Skip((currentPage - 1) * 10).Take(10);

            return View(categories);
        }


        public ActionResult Delete(int id)
        {
            try
            {
                _objBl.Delete(id);
                TempData["Msg"] = "Deleted Successfully!";
                return RedirectToAction("Index");
            }
            catch(Exception e1)
            {
                TempData["Msg"] = "Deletion Fail: " + e1.Message + " Error relate to: " + e1.Source;
                return RedirectToAction("Index");
            }
        }
    }
}