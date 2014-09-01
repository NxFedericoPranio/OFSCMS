using DataClasses.DataModel.Mail;
using DataClasses.DataModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OFSMVC.Controllers
{
    public class MailToUsController : OFSCore.Base.ControllerBase
    {
        //
        // GET: /MailToUs/

        //
        // GET: /Account/Register

        public ActionResult SendMail()
        {
            SetAngularJsValues();
            MailMessage m = new MailMessage();
            var view = View(m);
            ViewBag.Privacy = RegisterModel.PrivacyText();
            return view;
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult SendMail(MailMessage model)
        {
            model.IpAddress = Request.ServerVariables["REMOTE_ADDR"];
            MailMessagesXml xmlObjs = new MailMessagesXml(OFSCore.Folders.Mails);
            ViewBag.Privacy = RegisterModel.PrivacyText();
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                //Saving the xml file of the user
                if (xmlObjs.Save(model))
                {
                    OFSCore.MailManager.MailManager.SMTPAddress = OFSCore.Util.Parameters.MailSMTP;
                    OFSCore.MailManager.MailManager.SendMessage(OFSCore.Util.Parameters.AdminMail, model.Sender, model.Object, model.Message);

                    return RedirectToAction("Pages", "Home", new { id = 16 });
                }
                else
                {

                    // If we got this far, something failed, redisplay form
                    return RedirectToAction("Pages", "Home", new { id = 14 });
                }
                
            }

        return View(); 

        }

    }
}
