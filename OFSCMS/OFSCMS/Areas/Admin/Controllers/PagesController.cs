using DataClasses.DataModel.Generic;
using DataClasses.DataModel.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OFSCMS.Areas.Admin.Controllers
{
    [HandleError]
    public class PagesController : Controller
    {
        //
        // GET: /Admin/News/

        OFSPagesXml context = new OFSPagesXml(OFSCore.Folders.PageFolder);
        string divstart = "<div id=\"content\">";

        [Authorize(Roles = "Admin")]
        public ActionResult Index(string id = null)
        {
            return ListOfPages();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ListOfPages()
        {

            var pages = context.GetAll<OFSPage>();
            ActionResult view = View(pages);
            return view;
        }


        //
        // GET: /TestMain/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            OFSPage page = new OFSPage();
            page.Id = 0;
            page.Culture = OFSCore.LanguageManager.GetLanguage();
            //page.Content = "<div id=\"content\"><ofsctrl>" + page.Content + "<ofsctrl></div>";
            return View(page);
        }

        //
        // POST: /TestMain/Create
        [Authorize(Roles = "Admin")]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(OFSPage page)
        {
            if (ModelState.IsValid)
            {
                page.Culture = OFSCore.LanguageManager.GetLanguage();

                if (page.Content.StartsWith(divstart) || true)
                {
                    string ctrlBegin = "<ofsctrl>";
                    string ctrlEnd = "<ofsctrl>";


                    page.Content = page.Content.Replace("../../", OFSCore.Folders.WebRoot);
                    //page.Content = page.Content.Substring(page.Content.IndexOf(ctrlBegin) + ctrlBegin.Length, page.Content.Length - (page.Content.IndexOf(ctrlBegin) + ctrlBegin.Length));
                    //page.Content = page.Content.Substring(0, page.Content.IndexOf(ctrlEnd));
                }

                context.Save(page);
                return RedirectToAction("Index");
            }

            return View(page);
        }

        //
        // GET: /TestMain/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(string id)
        {
            OFSPage page = (OFSPage)context.Get<OFSPage>(id, OFSCore.LanguageManager.GetLanguage());
            page.Content = page.Content.Replace("../../", OFSCore.Folders.WebRoot);
            //page.Content = "<div id=\"content\">" + page.Content + "</div>";
            return View(page);
        }

        //
        // POST: /TestMain/Edit/5
        [Authorize(Roles = "Admin")]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(OFSPage page)
        {
            if (ModelState.IsValid)
            {
                page.Content = page.Content.Replace(OFSCore.Folders.WebRoot, "../../");
                //if (page.Content.StartsWith(divstart))
                //    page.Content = page.Content.Substring(divstart.Length, page.Content.Length - divstart.Length - 7 - 1);
                context.Save(page);
                return RedirectToAction("Index");
            }
            return View(page);
        }

        //
        // GET: /TestMain/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            OFSPage information = (OFSPage)context.Get<OFSPage>(id, OFSCore.LanguageManager.GetLanguage());
            //context.Delete(information);
            return View(information);
        }

        //
        // POST: /TestMain/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            OFSPage information = (OFSPage)context.Get<OFSPage>(id, OFSCore.LanguageManager.GetLanguage());
            context.Delete<OFSPage>(information);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ComboPages(int selectedPage)
        {
            ViewBag.SelectedPage = selectedPage;
            List<IOFSObject> appo = context.GetAll<OFSPage>();
            
            return PartialView(appo);
        }


    }
}