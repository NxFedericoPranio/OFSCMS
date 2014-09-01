using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OFSCore.Extension
{
    public static class ImageHelper
    {
        public static string Image(this HtmlHelper html, string imagePath)
        {
            var controller = html.ViewContext.RouteData.Values["controller"];
            var action = html.ViewContext.RouteData.Values["action"];
            var id = html.ViewContext.RouteData.Values["id"];
            var area = html.ViewContext.RouteData.DataTokens["area"];
            string res = imagePath;
            if (area != null)
            {
                res = "../" + res;
            }
            if (action.ToString().ToUpper() != "INDEX")
                return string.Concat("../../",  res);
            //    area = "Areas/" + area + "/";
            //return VirtualPathUtility.ToAbsolute("~/" + area + "Content/img/" + imagePath);
            return res;
        }
    }
}
