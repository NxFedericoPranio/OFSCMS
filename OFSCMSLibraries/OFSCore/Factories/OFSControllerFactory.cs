using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OFSCore.Factories
{   

    public class OFSControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            try
            {
                var controller = base.CreateController(requestContext, controllerName);
                HttpContext.Current.Session["controllerInstance"] = controller;
                return controller;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
