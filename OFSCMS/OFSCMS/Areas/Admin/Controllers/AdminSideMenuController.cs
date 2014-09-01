using DataClasses.DataModel.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OFSCMS.Areas.Admin.Controllers
{
    public class AdminSideMenuController : Controller
    {

        public ActionResult Show(string path)
        {

            ViewBag.ScriptName = Request.Url.LocalPath;
            OFSMenuesXml menu = new OFSMenuesXml(path + "\\Admin");
            menu.GetAll<OFSMenu>();
            return PartialView(
                menu.Items.First());
        }
       
    }
}
