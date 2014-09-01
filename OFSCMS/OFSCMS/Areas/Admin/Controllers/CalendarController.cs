using DataClasses.DataModel.Calendar;
using DataClasses.DataModel.Generic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OFSCMS.Areas.Admin.Controllers
{
    public class CalendarController : Controller
    {  //
        // GET: /Admin/News/

        IOFSObjects context = new OFSCalendarXml(OFSCore.Folders.CalendarFolder);

        [Authorize(Roles = "Admin")]
        public ActionResult Index(string id = null)
        {
            return ListOfNews();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ListOfNews()
        {

            var news = context.GetAll<OFSEvent>();
            ActionResult view = View(news);
            return view;
        }


        //
        // GET: /TestMain/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            OFSEvent info = new OFSEvent();
            info.Id = 0;
            info.Culture = OFSCore.LanguageManager.GetLanguage();
            info.Date = DateTime.Now;
            info.Time = new DateTime(2102, 1, 1, 9, 0, 0);
            return View(info);
        }

        //
        // POST: /TestMain/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(OFSEvent testmain)
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
            IOFSObject informtion = (IOFSObject)context.Get<OFSEvent>(id, OFSCore.LanguageManager.GetLanguage());
            return View(informtion);
        }

        //
        // POST: /TestMain/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(OFSEvent information)
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
            IOFSObject information = (IOFSObject)context.Get<OFSEvent>(id, OFSCore.LanguageManager.GetLanguage());
            //context.Delete(information);
            return View(information);
        }

        //
        // POST: /TestMain/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            IOFSObject information = (IOFSObject)context.Get<OFSEvent>(id, OFSCore.LanguageManager.GetLanguage());
            context.Delete<OFSEvent>(information);

            return RedirectToAction("Index");
        }


    }
}