using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataClasses.DataModel.Generic
{
    public interface IOFSObjects
    {
        string Path { get; set; }

        IOFSObject Get<T>(string id, string language);
        List<IOFSObject> Get(string id);
        List<IOFSObject> Get(ILoadingPolicy loadingPolicy);

        List<IOFSObject> GetAll<T>();

        bool Save(IOFSObject item);
        bool Delete<T>(IOFSObject item);

        List<IOFSObject> Items { get; set; }

        IOFSObject DependantIOFSPagesObject { get; }
    }
}
