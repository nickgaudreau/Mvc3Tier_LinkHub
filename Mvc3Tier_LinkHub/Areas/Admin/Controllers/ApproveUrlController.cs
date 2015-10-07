using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc3Tier_LinkHub.Areas.Admin.Controllers
{
    public class ApproveUrlController : BaseAdminController
    {
        // GET: Admin/ApproveUrl
        public ActionResult Index(string status)
        {
            ViewBag.Status = (status == null ? "P" : status);
            if (status == null)
            {
                var urls = _objBl.urlBl.GetAll().Where(x => x.c_IsApproved == "P").ToList();
                return View(urls);
            }
            else
            {
                var urls = _objBl.urlBl.GetAll().Where(x => x.c_IsApproved == status).ToList();
                return View(urls);
            }
        }

        //public ActionResult Approve(int id)
        //{
        //    try
        //    {
        //        var thisUrl = _objBl.urlBl.GetById(id);
        //        thisUrl.c_IsApproved = "A";
        //        _objBl.urlBl.Update(thisUrl);
        //        TempData["Msg"] = "Approved Successfully!";
        //        return RedirectToAction("Index");


        //    }
        //    catch (Exception e1)
        //    {
        //        TempData["Msg"] = "Approval Failed: " + e1.Message + " Error relate to: " + e1.Source;
        //        return RedirectToAction("Index");
        //    }
        //}

        //public ActionResult Reject(int id)
        //{
        //    try
        //    {
        //        var thisUrl = _objBl.urlBl.GetById(id);
        //        thisUrl.c_IsApproved = "R";
        //        _objBl.urlBl.Update(thisUrl);
        //        TempData["Msg"] = "Rejected Successfully!";
        //        return RedirectToAction("Index");


        //    }
        //    catch (Exception e1)
        //    {
        //        TempData["Msg"] = "Rejection Failed: " + e1.Message + " Error relate to: " + e1.Source;
        //        return RedirectToAction("Index");
        //    }
        //}

        public ActionResult StatusUpdate(int id, string status)
        {
            //try
            //{
                var thisUrl = _objBl.urlBl.GetById(id);
                thisUrl.c_IsApproved = status;
                _objBl.urlBl.Update(thisUrl);
                TempData["Msg"] = "Success!";
                return RedirectToAction("Index");
            //}
            //catch (Exception e1)
            //{
            //    TempData["Msg"] = "Failed: " + e1.Message + " Error relate to: " + e1.Source;
            //    return RedirectToAction("Index");
            //}
        }


    }
}