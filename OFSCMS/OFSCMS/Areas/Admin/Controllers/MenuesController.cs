using DataClasses.DataModel.Generic;
using DataClasses.DataModel.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OFSCMS.Areas.Admin.Controllers
{
    [HandleError]
    public class MenuesController : Controller
    {
   
        //
        // GET: /Admin/News/

        IOFSObjects context = new OFSMenuesXml(OFSCore.Folders.MenuFolder);

        [Authorize(Roles = "Admin")]
        public ActionResult Index(string id = null)
        {
            return ListOfNews();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ListOfNews()
        {
           
            var news = context.GetAll<OFSMenu>();
            ActionResult view = View(news);
            return view;
        }


        //
        // GET: /TestMain/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            OFSMenu info = new OFSMenu();
            info.Id = 0;
            info.Culture = OFSCore.LanguageManager.GetLanguage();

            ViewBag.ParentMenu = 0;

            ViewBag.PageRelated = 0;
            return View(info);
        }

        //
        // POST: /TestMain/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(OFSMenu testmain)
        {
            if (ModelState.IsValid)
            {
                testmain.Culture = OFSCore.LanguageManager.GetLanguage();
                context.Save(testmain);
                return RedirectToAction("Index");
            }

            return View(testmain);
        }

        //
        // GET: /TestMain/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string id)
        {
            OFSMenu informtion = (OFSMenu)context.Get<OFSMenu>(id, OFSCore.LanguageManager.GetLanguage());
            ViewBag.ParentMenu = informtion.Parent;

            ViewBag.PageRelated = informtion.PageId;
            return View(informtion);
        }

        //
        // POST: /TestMain/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(OFSMenu information)
        {
            if (ModelState.IsValid)
            {
                context.Save(information);
                return RedirectToAction("Index");
            }
            return View(information);
        }

        //
        // GET: /TestMain/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            OFSMenu information = (OFSMenu)context.Get<OFSMenu>(id, OFSCore.LanguageManager.GetLanguage());
            //context.Delete(information);
            return View(information);
        }

        //
        // POST: /TestMain/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            OFSMenu information = (OFSMenu)context.Get<OFSMenu>(id, OFSCore.LanguageManager.GetLanguage());
            context.Delete<OFSMenu>(information);
       
            return RedirectToAction("Index");
        }



        [Authorize(Roles = "Admin")]
        public ActionResult ComboMenu(int selectedMenu)
        {
            ViewBag.SelectedMenu = selectedMenu;
            List<IOFSObject> appo = context.GetAll<OFSMenu>();
            List<IOFSObject> res = new List<IOFSObject>();

            foreach (OFSMenu menu in appo)
            {
                res.Add(menu);
                foreach (OFSMenu menu2 in menu.MenuChildren.Children)
                {
                    res.Add(menu2);
                }
            }
            return PartialView(res);
        }

    }
}
