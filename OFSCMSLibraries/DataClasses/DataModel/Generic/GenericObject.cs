using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataClasses.DataModel.Generic
{
    public class GenericObject: IOFSObject
    {

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


        public int PageId { get; set; }

        public IOFSObject GetNewIstance()
        {
            return new GenericObject();
        }

        public void GetItemFronXML(System.Xml.Linq.XElement element, ref IOFSObject obj)
        {
            throw new NotImplementedException();
        }


    }
}
