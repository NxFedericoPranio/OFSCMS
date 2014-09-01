using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataClasses.DataModel.Generic
{
    public interface IOFSObject
    {
        int Id { get; set; }
        string Culture { get; set; }
        int PageId { get; set; }

        int IdSection { get; set; }
        int IdSite { get; set; }

        DateTime DateAdded { get; set; }
        DateTime DateModified { get; set; }
        bool Deleted { get; set; }
        DateTime DateDeleted { get; set; }

        IOFSObject GetNewIstance();
    }
}
