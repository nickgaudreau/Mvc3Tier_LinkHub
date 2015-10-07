using System;
using System.Linq;
using System.Web.Mvc;
using BLL;

namespace Mvc3Tier_LinkHub.Areas.Admin.Controllers
{
    public class ListUserController : BaseAdminController
    {
        
        // GET: Common/BrowseUrl
        public ActionResult Index(string sortOrder, string sortBy, string page)
        {
            ViewBag.SortOrder = sortOrder; // we pass this so the opposite sorting is pass into the Query string when clicked again
            ViewBag.SortBy = sortBy;
            var users = _objBl.userBl.GetAll();

            switch (sortBy)
            {
                case "UserEmail":
                    switch (sortOrder)
                    {
                        case "Asc":
                            users = users.OrderBy(x => x.c_UserEmail).ToList();
                            break;
                        case "Desc":
                            users = users.OrderByDescending(x => x.c_UserEmail).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "Role":
                    switch (sortOrder)
                    {
                        case "Asc":
                            users = users.OrderBy(x => x.c_Role).ToList();
                            break;
                        case "Desc":
                            users = users.OrderByDescending(x => x.c_Role).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                
                default:
                    users = users.OrderBy(x => x.c_UserEmail).ToList();
                    break;

            }

            // Find page count. If 10 records per page and we have 37 records then it is 4 pages
            ViewBag.TotalPages = Math.Ceiling(_objBl.userBl.GetAll().Count() /10.0 );

            int currentPage = int.Parse(page == null ? "1" : page);

            ViewBag.Page = currentPage; // to know which page to highlight even when we sort, and in the query string

            // take the current page - 1 and mutli by 10 to give a start point in the data, then take next 10 records to display
            users = users.Skip((currentPage - 1) * 10).Take(10);

            return View(users);
        }
    }
}