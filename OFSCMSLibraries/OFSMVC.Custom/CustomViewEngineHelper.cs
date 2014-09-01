﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OFSMVC.Custom
{
    public class CustomViewEngineHelper
    {
        internal static string[] AddNewLocationFormats(IEnumerable<string> defaultLocationFormats,
                                                       IEnumerable<string> newLocationFormats)
        {
            List<string> allItems = new List<string>(newLocationFormats);
            foreach (string s in defaultLocationFormats)
            {
                allItems.Add(s);
            }

            return allItems.ToArray();
        }


        internal static string OverrideMasterPage(string masterName, ControllerContext controllerContext)
        {
            if (NeedChangeMasterPage(controllerContext))
            {
                masterName = Utils.SkinName;
            }

            return masterName;
        }

        private static bool NeedChangeMasterPage(ControllerContext context)
        {
            SupportSkinAttribute attr = Attribute.GetCustomAttribute(context.Controller.GetType(),
                                                                     typeof(SupportSkinAttribute)) as
                                        SupportSkinAttribute;
            return null != attr;
        }
    }
}