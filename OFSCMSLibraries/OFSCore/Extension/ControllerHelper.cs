

using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace OFSCore.Extension
{
    public static class ControllerHelper
    {
        

        //@model Customer
        //<html>
        //  <body>
        //    <p>Ciao, @this.Model.Name</p>

        //    <p>ti scriviamo questa mail per dimostrare quanto Razor sia versatile!</p>
        //  </body>
        //</html>


        //public ActionResult SendEmail(...)
        //{
        //  var customer = new Customer() 
        //  {
        //    Name = "Marco De Sanctis"
        //  };

        //  string body = this.ViewToString("emailTemplate", customer);
        //  // invio email qui ...
        //}
        public static string ViewToString(this Controller controller, string viewName, object model)
        {
            var controllerContext = new ControllerContext(
              controller.HttpContext, controller.RouteData, controller);

            var viewResult = ViewEngines.Engines.FindPartialView(controllerContext, viewName);

            using (var sw = new StringWriter())
            {
                var viewContext = new ViewContext(
                  controllerContext, viewResult.View,
                  new ViewDataDictionary(), new TempDataDictionary(), sw);//new TempDataDictionary<T>()
                viewContext.ViewData.Model = model;

                try
                {
                    viewResult.View.Render(viewContext, sw);
                }
                finally
                {
                    viewResult.ViewEngine.ReleaseView(controllerContext, viewResult.View);
                }

                return sw.ToString();
            }
        }
    }


}


