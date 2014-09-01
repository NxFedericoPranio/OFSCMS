using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OFSMVC.Custom
{
    public class OFSRazorViewEngine : RazorViewEngine
    {
        public OFSRazorViewEngine()
        {
            string[] mastersLocation = new[]
                                           {
                                               string.Format("~/skins/{0}/views/{0}.cshtml",
                                                             Utils.SkinName)
                                           };
            MasterLocationFormats = CustomViewEngineHelper.AddNewLocationFormats(
                new List<string>(MasterLocationFormats),
                mastersLocation);

            string[] viewsLocation = new[]
                                         {
                                             string.Format("~/skins/{0}/Views/{{1}}/{{0}}.cshtml",
                                                           Utils.SkinName)
                                         };
            ViewLocationFormats =
                PartialViewLocationFormats =
                CustomViewEngineHelper.AddNewLocationFormats(new List<string>(ViewLocationFormats),
                                                             viewsLocation);
        }

        public override ViewEngineResult FindView(ControllerContext controllerContext,
                                                  string viewName,
                                                  string masterName,
                                                  bool useCache)
        {
            masterName = CustomViewEngineHelper.OverrideMasterPage(masterName,
                                                                   controllerContext);
            return base.FindView(controllerContext,
                                 viewName,
                                 masterName,
                                 useCache);
        }
    }
    
}
