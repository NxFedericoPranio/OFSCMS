using DataClasses.DataModel.Generic;
using DataClasses.DataModel.Guestbook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OFSMVC.Controllers
{
    public class GuestBookController : OFSCore.Base.ControllerBase
    {
        //
        // GET: /GuestBook/
        string pathNews = string.Empty;
        IOFSObjects context = new GuestMessagesXml(OFSCore.Folders.GuestBook);

        public ActionResult Sign()
        {
            GuestMessage m = new GuestMessage();
            m.Culture = "it-IT";
            var view = PartialView(m);
            
            ViewBag.Privacy = GuestMessage.PrivacyText();
            return view;
        }

        [HttpPost]
        public ActionResult Sign(GuestMessage model)
        {
            model.IpAddress = Request.ServerVariables["REMOTE_ADDR"];
            GuestMessagesXml xmlObjs = new GuestMessagesXml(OFSCore.Folders.GuestBook);
            ViewBag.Privacy = GuestMessage.PrivacyText();
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                //Saving the xml file of the user
                if (xmlObjs.Save(model))
                {
                    OFSCore.MailManager.MailManager.SMTPAddress = OFSCore.Util.Parameters.MailSMTP;
                    OFSCore.MailManager.MailManager.SendMessage(OFSCore.Util.Parameters.AdminMail, model.Sender, string.Concat("Inserito nuovo post: ", model.Title), model.Message);
                    storeUnapproedItemInSession(model);
                    return RedirectToAction("Show", "GuestBook");
                }
                else
                {

                    // If we got this far, something failed, redisplay form
                    return RedirectToAction("Pages", "Home", new { id = 14 });
                }

            }

            return View();

        }

        private void storeUnapproedItemInSession(IOFSObject item){
            if (Session["UnapprovedGuestBook"] == null)
                Session["UnapprovedGuestBook"] = new List<IOFSObject>();

            List<IOFSObject> list = (List<IOFSObject>)Session["UnapprovedGuestBook"];
            list.Add(item);
            Session["UnapprovedGuestBook"] = list;
        }

        public ActionResult GetNumberOfPosts()
        {
            var news = context.GetAll<GuestMessage>();
            ActionResult view = Json(news.Count(), JsonRequestBehavior.AllowGet);
            base.ModelCount = news.Count();
            return view;
        }

        public ActionResult ShowAjax(int Page)
        {
            List<IOFSObject> news = new List<IOFSObject>();
            if (Session["UnapprovedGuestBook"] != null)
            {
                List<GuestMessage> list = ((List<IOFSObject>)Session["UnapprovedGuestBook"]).Cast<GuestMessage>().ToList();
                news.AddRange(list);
            }
            news.AddRange(context.GetAll<GuestMessage>().OrderByDescending(i => i.Id).Where(p => ((GuestMessage)p).IsAapproved).Skip(Page * PageSize).Take(PageSize).ToList());
          
            ActionResult view = Json(news, JsonRequestBehavior.AllowGet);
            base.ModelCount = news.Count();
            return view;
        }


        public ActionResult Show(int _escaped_fragment_ = 0)
        {

            SetAngularJsValues();
            List<IOFSObject> news = new List<IOFSObject>();
            if (Session["UnapprovedGuestBook"] != null)
            {
                List<GuestMessage> list = ((List<IOFSObject>)Session["UnapprovedGuestBook"]).Cast<GuestMessage>().ToList();
                news.AddRange(list);
            }
            news.AddRange(context.GetAll<GuestMessage>().OrderByDescending(i => i.Id).Where(p => ((GuestMessage)p).IsAapproved).Skip(_escaped_fragment_ * PageSize).Take(PageSize).ToList());
            ActionResult view = View(news);
            base.ModelCount = news.Count();
            return view;
        }
    }
}
