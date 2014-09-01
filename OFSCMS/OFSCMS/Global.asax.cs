using OFSCore.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace OFSCMS
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {

  
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);

            AreaRegistration.RegisterAllAreas();

            //// Use LocalDB for Entity Framework by default
            //Database.DefaultConnectionFactory = new SqlConnectionFactory("Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True");

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            ViewEngines.Engines.Add(new OFSMVC.Custom.OFSRazorViewEngine());

            ControllerBuilder.Current.SetControllerFactory(new OFSControllerFactory());
        }

        public void Session_Start(Object sender, EventArgs e)
        {
            //OFSSession = new OFSCore.Util.OFSSession(Session);
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "DefaultAspx",
                "{controller}/{action}/{id}.htm",
                new { controller = "Home", action = "Index" }

            );

        }

        protected void Application_Error()
        {
            if (OFSCore.Util.Parameters.ErrorHandling)
            {
                string message = string.Empty;
                Exception exception = Server.GetLastError();

                if (exception.Message == "The IControllerFactory 'OFSCore.Factories.OFSControllerFactory' did not return a controller for the name 'Content'.")
                    return;

                Response.Clear();

                HttpException httpException = exception as HttpException;

                if (httpException != null)
                {
                    string action;

                    switch (httpException.GetHttpCode())
                    {
                        case 404:
                            // page not found
                            action = "HttpError404";
                            break;
                        case 500:
                            // server error
                            action = "HttpError500";
                            break;
                        default:
                            action = "General";
                            break;
                    }

                }
                if (exception == null)
                    return;
                //OFSCore.Util.Log.AddLogEntry(exception.Message);
                message += exception.Message + "\n";
                message += exception.StackTrace + "\n";
                message += "\n";
                while (exception.InnerException != null)
                {
                    exception = exception.InnerException;
                    message += exception.Message + "\n";
                    message += exception.StackTrace + "\n";
                    message += "\n";
                    OFSCore.Util.Log.AddLogEntry(exception.Message);

                }
                OFSCore.MailManager.MailManager.SMTPAddress = OFSCore.Util.Parameters.MailSMTP;
                OFSCore.MailManager.MailManager.SendMessage(OFSCore.Util.Parameters.AdminMail, OFSCore.Util.Parameters.AdminMail, "Messaggio dal sito pranio.it di ERRORE", message);

                OFSCore.Util.Log.SaveLog(OFSCore.Folders.BaseFolder + "Log\\" + OFSCore.Util.Log.GetLogFileName() + ".txt", true);
                // clear error on server
                Server.ClearError();

                //Response.Redirect("./home/pages/14");
            }
        }
    }
}