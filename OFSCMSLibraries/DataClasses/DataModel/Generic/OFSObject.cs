using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DataClasses.DataModel.Generic
{
    [XmlRootAttribute("ROOT", Namespace = "http://www.OfsCms.com", IsNullable = false)]
    public class OFSObject: IOFSObject
    {
        [XmlAttribute("id")]
        public int Id
        {
            get; set;
        }

        [XmlAttribute("culture")]
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
            throw new NotImplementedException();
        }
    }
}
