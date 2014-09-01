using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Web.Script.Serialization;
using DataClasses.OFS.PhotoGallery;
using DataClasses;
using OFSCore.Extension;
using System.Threading.Tasks;
using DataClasses.DataModel.Pages;

namespace OFSMVC.Controllers
{
    public class HomeController : OFSCore.Base.ControllerBase
    {
        public ActionResult Index(string id = null)
        {            
            if (id == null) {
                return Pages();
            }
            else return new RedirectResult(string.Format("Home/Pages/{0}", id.ToString()));
        }

        
        public ActionResult Pages(string id = null)
        {
            ActionResult view = GetSpecialView(id);
            ViewBag.IsSubApp = true;
            if (view != null)
                return view;

            ViewBag.IsSubApp = false;
            SetAngularJsValues();
            if (id == null)
                id = "1";
            OFSPage page = GetPage(id);
            view = ShowPage(page);
            return view;
        }

        private void SetAngularJsValues()
        {
            if (!ViewBag.IsSubApp)
            {
                ViewData["angularApp"] = "ng-app=\"ofsApp\"";
                ViewData["angularView"] = "ng-view";
            }
        }

        public ActionResult GetSpecialView(string id = null)
        {
            if (id == null)
            {
                return null;
            }


            //Case of the photogallery

            if (id == "6")
            {
                return RedirectToAction("Gallery", "Photo", new { Name = "Io", page = 0 });
            }

            if (id == "4")
            {
                return RedirectToAction("ListOfNews", "NewsClient");
            }

            if (id == "5")
            {
                return RedirectToAction("ListOfEvents", "CalendarClient");
            }

            if (id == "15")
            {
                return RedirectToAction("SendMail", "MailToUs");
            }
            if (id == "17")
            {
                return RedirectToAction("Order", "Orders");
            }

            if (id == "50")
            {
                return RedirectToAction("Show", "GuestBook");
            }

            return null;
        }

        public OFSPage GetPage(string id)
        {
            OFSPagesXml pages = new OFSPagesXml(OFSCore.Folders.PageFolder);
            OFSPage page = (OFSPage)pages.Get<OFSPage>(id, "it-it");

            ViewBag.Title = page.Title;
            ViewBag.Keywords = page.Keywords;
            ViewBag.Description = page.SeoTitle;
            ViewBag.ScriptName = Request.Url.LocalPath;

            if (page.Content.IndexOf("[NEWS]") >= 0)
                page.Content = page.Content.Replace("[NEWS]", OFSCore.HtmlElements.NewsBox.GetHtml(OFSCore.Folders.NewsFolder));


            if (page.Content.IndexOf("[EVENTS]") >= 0)
                page.Content = page.Content.Replace("[EVENTS]", OFSCore.HtmlElements.CalendarBox.GetHtml(OFSCore.Folders.CalendarFolder));

            return page;
        }

        public ActionResult PageAjax(string id)
        {
            return Json(GetPage(id), JsonRequestBehavior.AllowGet);
        }


        public ActionResult Page(string _escaped_fragment_)
        {
            return ShowPage(GetPage(_escaped_fragment_));
        }

        private ActionResult ShowPage(string page, OFSPage entry)
        {
            return View(page, entry);
        }

        private ActionResult ShowPage(OFSPage entry)
        {
            return View("Index", entry);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
