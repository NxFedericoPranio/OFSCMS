using DataClasses.DataModel.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataClasses.DataModel.Generic
{
    public abstract class OFSObjects : IOFSObjects
    {
        public virtual string Path
        {
            get; set;
        }

        public virtual IOFSObject Get<T>(string id, string language)
        {
            return null;
        }

        public virtual List<IOFSObject> Get(string id)
        {
            return null;
        }

        public virtual List<IOFSObject> Get(ILoadingPolicy loadingPolicy)
        {
            return null;
        }

        public virtual List<IOFSObject> GetAll<T>()
        {
            return null;
        }

        public virtual bool Save(IOFSObject item)
        {
            return false;
        }

        public virtual bool Delete<T>(IOFSObject item)
        {
            return false;
        }

        public virtual List<IOFSObject> Items
        {
            get;
            set;
        }

        public IOFSObject DependantIOFSPagesObject
        {
            get;
            set;
            
        }
    }
}
