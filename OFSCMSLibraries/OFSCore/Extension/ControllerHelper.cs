

using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace OFSCore.Extension
{
    public static class ControllerHelper
    {
        /// <summary>
        /// Captures the HTML output by a controller action that returns a ViewResult
        /// </summary>
        /// <typeparam name="TController">The type of controller to execute the action on</typeparam>
        /// <param name="controller">The controller</param>
        /// <param name="action">The action to execute</param>
        /// <returns>The HTML output from the view</returns>
        public static string CaptureActionHtml<TController>(
            this TController controller,
            Func<TController, ViewResult> action)
            where TController : Controller
        {
            return controller.CaptureActionHtml(controller, null, action);
        }

        /// <summary>
        /// Captures the HTML output by a controller action that returns a ViewResult
        /// </summary>
        /// <typeparam name="TController">The type of controller to execute the action on</typeparam>
        /// <param name="controller">The controller</param>
        /// <param name="masterPageName">The master page to use for the view</param>
        /// <param name="action">The action to execute</param>
        /// <returns>The HTML output from the view</returns>
        public static string CaptureActionHtml<TController>(
            this TController controller,
            string masterPageName,
            Func<TController, ViewResult> action)
            where TController : Controller
        {
            return controller.CaptureActionHtml(controller, masterPageName, action);
        }

        /// <summary>
        /// Captures the HTML output by a controller action that returns a ViewResult
        /// </summary>
        /// <typeparam name="TController">The type of controller to execute the action on</typeparam>
        /// <param name="controller">The current controller</param>
        /// <param name="targetController">The controller which has the action to execute</param>
        /// <param name="action">The action to execute</param>
        /// <returns>The HTML output from the view</returns>
        public static string CaptureActionHtml<TController>(
            this Controller controller,
            TController targetController, 
            Func<TController, ViewResult> action)
            where TController : Controller
        {
            return controller.CaptureActionHtml(targetController, null, action);
        }

        /// <summary>
        /// Captures the HTML output by a controller action that returns a ViewResult
        /// </summary>
        /// <typeparam name="TController">The type of controller to execute the action on</typeparam>
        /// <param name="controller">The current controller</param>
        /// <param name="targetController">The controller which has the action to execute</param>
        /// <param name="masterPageName">The name of the master page for the view</param>
        /// <param name="action">The action to execute</param>
        /// <returns>The HTML output from the view</returns>
        public static string CaptureActionHtml<TController>(
            this Controller controller,
            TController targetController, 
            string masterPageName,
            Func<TController, ViewResult> action)
            where TController : Controller
        {
            if (controller == null)
            {
                throw new ArgumentNullException("controller");
            }
            if (targetController == null)
            {
                throw new ArgumentNullException("targetController");
            }
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            // pass the current controller context to orderController
            var controllerContext = controller.ControllerContext;
            targetController.ControllerContext = controllerContext;

            // replace the current context with a new context that writes to a string writer
            var existingContext = System.Web.HttpContext.Current;
            var writer = new StringWriter();
            var response = new HttpResponse(writer);
            var context = new HttpContext(existingContext.Request, response) {User = existingContext.User};
            System.Web.HttpContext.Current = context;

            // execute the action
            var viewResult = action(targetController);

            // change the master page name
            if (masterPageName != null)
            {
                viewResult.MasterName = masterPageName;
            }

            // we have to set the controller route value to the name of the controller we want to execute
            // because the ViewLocator class uses this to find the correct view
            var oldController = controllerContext.RouteData.Values["controller"];
            controllerContext.RouteData.Values["controller"] = typeof(TController).Name.Replace("Controller", "");

            // execute the result
            viewResult.ExecuteResult(controllerContext);

            // restore the old route data
            controllerContext.RouteData.Values["controller"] = oldController;

            // restore the old context
            System.Web.HttpContext.Current = existingContext;

            return writer.ToString();
        }

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
        public static string ViewToString<T>(this Controller controller, string viewName, T model)
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


    //public class TestController : Controller
    //{
    //    private readonly OrderController orderController;
    //    private readonly ILogger logger;

    //    public TestController(OrderController orderController, ILogger logger)
    //    {
    //        this.orderController = orderController;
    //        this.logger = logger;
    //    }

    //    public ActionResult Index()
    //    {
    //        string html = this.CaptureActionHtml(orderController, "Print", c => (ViewResult)c.Item(8));

    //        logger.Info(html);

    //        // do a redirect
    //        return RedirectToRoute(new { Controller = "Order", Action = "Item", Id = 8 });
    //    }
    //}
}


