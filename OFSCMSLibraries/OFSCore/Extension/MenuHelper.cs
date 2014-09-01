using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DataClasses;
using DataClasses.OFS.PhotoGallery;
using System.Web.Routing;
using DataClasses.DataModel.Menu;
using System.Linq.Expressions;
using OFSCore.Util;
using System.Reflection.Emit;
using System.Reflection;
using System.Dynamic;

namespace OFSCore.Extension
{


    public static class MenuHelper
    {
        public static string BuildMenuLink(this UrlHelper urlHelper, OFSMenu item)
        {
            if (!string.IsNullOrEmpty(item.HRef))
            {
                return item.HRef.Replace("[PAGEROOT]/", OFSCore.Folders.WebRoot);
            }


            //    return 
            //        OFSCore.Folders.WebRoot
            //            + urlHelper.Action("Pages",
            //                            "Home",
            //                            new { id = item.PageId }).ToLower();

            object parameters;
            if (string.IsNullOrEmpty(item.Parameters))
            {
                parameters = new { id = item.PageId };
            }
            else
            {
                dynamic data = new ExpandoObject();
                IDictionary<string, object> d = (IDictionary<string, object>)data;
                string[] sParams = item.Parameters.Split(',');
                foreach (string v in sParams)
                {
                    string[] sVal = v.Split('=');
                    d.Add(sVal[0], sVal[1]);
                }

                parameters = d;

            }


            if (!IsSinglePageApplication(item))
            {
                return
                    OFSCore.Folders.WebRoot
                        + urlHelper.Action(item.Action,
                                        item.Controller,
                                        parameters).ToLower();
            }
            else
            {
                return OFSCore.Folders.WebRoot + "#" + urlHelper.Action(item.Action,
                                        item.Controller,
                                        parameters).ToLower();
            }

        }

        public static string BuildPagerLink(this UrlHelper urlHelper, Gallery gallery, int selectedPage)
        {
            var a = new { Name = gallery.GalleryName, page = selectedPage };
            return urlHelper.Action("Gallery", "Photo", new { Name = gallery.GalleryName, page = selectedPage });
        }

        public static string BuildPagerLink(this UrlHelper urlHelper, string Controller, string Action, RouteValueDictionary Params, int selectedPage)
        {
            if (Params == null)
                Params = new RouteValueDictionary();
            Params.Add("page", selectedPage.ToString());
            return urlHelper.Action(Action, Controller, Params);
        }

        private static bool IsSinglePageApplication(OFSMenu item)
        {
            return (item.IsSPA);
        }
    }
        
}
