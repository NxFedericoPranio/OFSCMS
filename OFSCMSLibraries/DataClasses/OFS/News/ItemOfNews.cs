using DataClasses.DataModel.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataClasses.OFS.News
{
    public class ItemOfNews: DataModel.Pages.OFSPage
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

        public string Title
        {

            get;
            set;
        }

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

        public int Id
        {

            get;
            set;
        }

        public string Culture
        {

            get;
            set;
        }

        public int PageId
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

        public IOFSObject GetNewIstance()
        {
            return new ItemOfNews();
        }
    }
}
