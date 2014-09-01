using DataClasses.DataModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataClasses.DataModel.Orders;
using DataClasses.DataModel.Mail;

namespace OFSMVC.Controllers
{
    public class OrdersController : OFSCore.Base.ControllerBase
    {
        //
        // GET: /Orders/

        public ActionResult Order()
        {
            SetAngularJsValues();
            Order m = new Order();
            var view = View(m);
            ViewBag.Privacy = RegisterModel.PrivacyText();
            return view;
        }
        [HttpPost]
        public ActionResult Order(Order Model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                //Saving the xml file of the user

                OrdersXml xmlObjs = new OrdersXml(OFSCore.Folders.Orders);
                if (xmlObjs.Save(Model))
                {
                    string message = getMessageForSeller(Model);
                    OFSCore.MailManager.MailManager.SMTPAddress = OFSCore.Util.Parameters.MailSMTP;
                    OFSCore.MailManager.MailManager.SendMessage(OFSCore.Util.Parameters.AdminMail, Model.Sender, Model.Object, message);

                    message = getMessageForCustomer(Model);

                    OFSCore.MailManager.MailManager.SendMessage(Model.Sender, OFSCore.Util.Parameters.AdminMail, Model.Object, message);
                    return RedirectToAction("Pages", "Home", new { id = 18 });
                }
                else
                {

                    // If we got this far, something failed, redisplay form
                    return RedirectToAction("Pages", "Home", new { id = 14 });
                }

            }
            Order m = new Order();
            return View(m);
        }


        private string getMessageForSeller(Order order)
        {
            return "ORDINANTE: \r\n" + 
                "Nome: " + order.Name + " " +order.Surname +"\r\n" +
                "Indirizzo: " + order.Address + " " +order.CNumber +"\r\n" +
                "Città: " + order.City + " CAP: " +order.ZipCode +"\r\n" +
                "Prov: " + order.Country + "\r\n" +
                "Email: " + order.Sender + "\r\n" +
                "Telefono: " + order.TelephonNumber + "\r\n" +
                "\r\nORDINE:  \r\n" +
                "Libri ordinati: " + order.QuantityVal + "\r\n"
                ;

        }

        private string getMessageForCustomer(Order order)
        {
            return "\r\n" +
                "Egr. Sig.: " + order.Name + " " + order.Surname + "\r\n" +
                string.Format("Hai ordinato {0} copie del libro \"Carmelo Borg Pisani\"", order.QuantityVal) + "\r\n" +
                "Ti saranno spedite, una volta effettuato il pagamento al seguente " +
                 "indirizzo: " + order.Address + " " +order.CNumber +"\r\n" +
                "Città: " + order.City + " CAP: " +order.ZipCode +"\r\n" +
                "Prov: " + order.Country + "\r\n" +
                "Email: " + order.Sender + "\r\n" +
                "Telefono: " + order.TelephonNumber + "\r\n";

        }

    }
}
