using DataClasses.DataModel.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OFSMVC.Controllers
{
    public class SideMenuController : OFSCore.Base.ControllerBase
    {

        public ActionResult Show(string path)
        {

            OFSMenuesXml menu = new OFSMenuesXml(path);
            menu.GetAll<OFSMenu>();
            return PartialView(
                menu.Items);
        }
       
    }
}
