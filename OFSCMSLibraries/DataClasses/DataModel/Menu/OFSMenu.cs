using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.Xml.Serialization;
using DataClasses.DataModel.Generic;

namespace DataClasses.DataModel.Menu
{
    [XmlRootAttribute("ROOT", Namespace = "http://www.OfsCms.com", IsNullable = false)]
    public class OFSMenu : OFSObject
    {
        #region IOFSMenu interface
        public int Parent
        {
            get;
            set;
        }

        public bool IsVisible
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        public string HRef
        {
            get;
            set;
        }


        public int PageRefId
        {
            get;
            set;
        }

        public int PageOwnerId
        {
            get;
            set;
        }

        public bool VisibleOnChildren
        {
            get;
            set;
        }

        public OFSMenuChildren MenuChildren
        {
            get;
            set;
        }


        public int IdSection
        {
            get;
            set;
        }

        public int IdSite
        {
            get;
            set;
        }


        public string SeoTitle
        {
            get;
            set;
        }


        int Page { get; set; }



        public string Controller
        {
            get;
            set;
        }
        public string Action
        {
            get;
            set;
        }
        public string Parameters
        {
            get;
            set;
        }

        public bool IsSPA
        {
            get;
            set;
        }
       
        #endregion


        public IOFSObject GetNewIstance()
        {
            return new OFSMenu();
        }

        public OFSMenu()
        {
            MenuChildren = new OFSMenuChildren();
        }



        
    }
}
