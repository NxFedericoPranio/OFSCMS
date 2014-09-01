using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
using DataClasses.DataModel.Generic;

namespace DataClasses.DataModel.News
{
    [XmlRoot("ROOT")]
    public class OFSNew :OFSObject
    {
        public int Parent
        {
            get;
            set;
        }

        public bool IsMenuItem
        {
            get;
            set;
        }
        [Required]
        [Display(Name = "Title")]
        public string Title
        {
            get;
            set;
        }
        [Required]
        [Display(Name = "Seo Title")]
        public string SeoTitle
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

        public string Content
        {
            get;
            set;
        }

        public string UrlMap
        {
            get;
            set;
        } 

        public IOFSObject GetNewIstance()
        {
            return new OFSNew();
        }
    }
}
