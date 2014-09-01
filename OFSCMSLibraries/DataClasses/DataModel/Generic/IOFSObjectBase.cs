using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataClasses.DataModel.Generic
{
    internal interface IOFSObjectBase
    {
        string Path { get; set; }

        IOFSObject Get<T>(string id, string language);
        List<IOFSObject> Get(string id);
        List<IOFSObject> Get(ILoadingPolicy loadingPolicy);

        List<IOFSObject> GetAll();

        bool Save(IOFSObject item);
        bool Delete<T>(IOFSObject item);

        List<IOFSObject> Items { get; set; }

        IOFSObject DependantIOFSPagesObject { get; }
    }
}
