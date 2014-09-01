using DataClasses.DataModel.Generic;
using DataClasses.DataModel.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OFSCMS.Areas.Admin.Controllers
{
    [HandleError]
    public class NewsController : Controller
    {
        //
        // GET: /Admin/News/

        IOFSObjects context = new OFSNewsXml(OFSCore.Folders.NewsFolder);

        [Authorize(Roles = "Admin")]
        public ActionResult Index(string id = null)
        {
            return ListOfNews();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ListOfNews()
        {
           
            var news = context.GetAll<OFSNew>();
            ActionResult view = View(news);
            return view;
        }


        //
        // GET: /TestMain/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            OFSNew info = new OFSNew();
            info.Id = 0;
            info.Culture = OFSCore.LanguageManager.GetLanguage();
            return View(info);
        }

        //
        // POST: /TestMain/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(OFSNew testmain)
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
            OFSNew informtion = (OFSNew)context.Get<OFSNew>(id, OFSCore.LanguageManager.GetLanguage());
            return View(informtion);
        }

        //
        // POST: /TestMain/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(OFSNew information)
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
            OFSNew information = (OFSNew)context.Get<OFSNew>(id, OFSCore.LanguageManager.GetLanguage());
            //context.Delete(information);
            return View(information);
        }

        //
        // POST: /TestMain/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            OFSNew information = (OFSNew)context.Get<OFSNew>(id, OFSCore.LanguageManager.GetLanguage());
            context.Delete<OFSNew>(information);
       
            return RedirectToAction("Index");
        }


    }
}
