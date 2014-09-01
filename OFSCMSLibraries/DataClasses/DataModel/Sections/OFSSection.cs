using DataClasses.DataModel.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataClasses.DataModel.Sections
{
    public class OFSSection :OFSObject
    {
        

        public string Name
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public int SectionMenu
        {
            get;
            set;
        }

        public int StartPage
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

        public int IdSite
        {
            get;
            set;
        }

        public IOFSObject GetNewIstance()
        {
            throw new NotImplementedException();
        }

    }
}
