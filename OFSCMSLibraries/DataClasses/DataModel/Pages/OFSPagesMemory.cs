using DataClasses.DataModel.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataClasses.DataModel.Pages
{
    public class OFSPagesMemory: IOFSObjects
    {
        IOFSObjects pagesDependancy = null;
        public string Path
        {
            get;
            set;
        }

        public IOFSObject Get<T>(string id, string language)
        {
            throw new NotImplementedException();
        }

        public List<IOFSObject> Get(string id)
        {
            throw new NotImplementedException();
        }

        public bool Save(IOFSObject item)
        {
            throw new NotImplementedException();
        }

        public bool Delete<T>(IOFSObject item)
        {
            throw new NotImplementedException();
        }

        public List<IOFSObject> Items
        {
            get;
            set;
        }


        public IOFSObject DependantIOFSPagesObject
        {
            get { return (IOFSObject)pagesDependancy; }
        }

        public OFSPagesMemory(OFSPagesXml ofsPageXml)
        {
            this.pagesDependancy = ofsPageXml;
            pagesDependancy.GetAll<OFSPage>();
        }


        public List<IOFSObject> Get(ILoadingPolicy loadingPolicy)
        {
            throw new NotImplementedException();
        }

        public List<IOFSObject> GetAll<T>()
        {
            throw new NotImplementedException();
        }
    }
}
