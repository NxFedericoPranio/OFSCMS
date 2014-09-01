using DataClasses.DataModel.Generic;
using DataClasses.DataModel.Guestbook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OFSCMS.Areas.Admin.Controllers
{
    public class GuestBookAdminController : Controller
    {
        IOFSObjects context = new GuestMessagesXml(OFSCore.Folders.GuestBook);

        [Authorize(Roles = "Admin")]
        public ActionResult Index(string id = null)
        {
            return ListOfMessages();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ListOfMessages()
        {

            var mess = context.GetAll<GuestMessage>();
            ActionResult view = View(mess);
            return view;
        }


        //
        // GET: /TestMain/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            GuestMessage info = new GuestMessage();
            info.Id = 0;
            info.Culture = OFSCore.LanguageManager.GetLanguage();
            return View(info);
        }

        //
        // POST: /TestMain/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(GuestMessage testmain)
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
            GuestMessage informtion = (GuestMessage)context.Get<GuestMessage>(id, OFSCore.LanguageManager.GetLanguage());
            informtion.Culture = OFSCore.LanguageManager.GetLanguage();
            return View(informtion);
        }

        //
        // POST: /TestMain/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(GuestMessage information)
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
            GuestMessage information = (GuestMessage)context.Get<GuestMessage>(id, OFSCore.LanguageManager.GetLanguage());
            //context.Delete(information);
            return View(information);
        }

        //
        // POST: /TestMain/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            GuestMessage information = (GuestMessage)context.Get<GuestMessage>(id, OFSCore.LanguageManager.GetLanguage());
            context.Delete<GuestMessage>(information);

            return RedirectToAction("Index");
        }

    }
}
