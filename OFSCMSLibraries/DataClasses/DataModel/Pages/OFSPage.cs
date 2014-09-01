using DataClasses.DataModel.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace DataClasses.DataModel.Pages
{
    [XmlRoot("ROOT")]
    public class OFSPage : IOFSObject
    {
        public string Title
        {
            get;
            set;
        }

        public string Css
        {
            get;
            set;
        }

        public string Js
        {
            get;
            set;
        }

        public string Keywords
        {
            get;
            set;
        }

        [XmlAttribute("id")]
        public int Id
        {
            get;
            set;
        }


        [XmlAttribute("culture")]
        public string Culture
        {
            get;
            set;
        }


        public string Content
        {
            get;
            set;
        }

        [XmlIgnore]
        public string PageContent
        {
            get { return Content; }
        }

        public DateTime DateAdded
        {
            get;
            set;
        }

        public DateTime DateModified
        {
            get;
            set;
        }

        public bool Deleted
        {
            get;
            set;
        }

        public DateTime DateDeleted
        {
            get;
            set;
        }



        public int Parent
        {
            get;
            set;
        }




        public string UrlMap
        {
            get;
            set;
        }


        public bool IsMenuItem
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

        public int PageId { get; set; }

        public OFSPageBox Box1 { get; set; }
        public OFSPageBox Box2 { get; set; }
        public OFSPageBox Box3 { get; set; }

        public OFSPageBox Box4 { get; set; }


        
        public IOFSObject GetNewIstance()
        {
            return new OFSPage();
        }


        public void GetItemFronXML(System.Xml.Linq.XElement element, ref IOFSObject obj)
        {
            throw new NotImplementedException();
        }



    }
}