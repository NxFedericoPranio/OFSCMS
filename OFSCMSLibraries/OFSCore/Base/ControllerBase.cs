using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace OFSCore.Base
{
    public class ControllerBase: Controller
    {
        int pageSize = 12;

        public int PageSize
        {
          get { return pageSize; }
          set { pageSize = value; }
        }

        public int ModelCount
        {
            get; set;
        }

        protected void SetAngularJsValues()
        {
            ViewData["angularApp"] = string.Empty;
            ViewData["angularView"] = string.Empty;
        }


        
    }
}
