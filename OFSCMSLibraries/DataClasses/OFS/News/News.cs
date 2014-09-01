using DataClasses.DataModel.Generic;
using DataClasses.DataModel.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataClasses.OFS.News
{
    public class News: IOFSObjects
    {
        public string Path
        {

            get;
            set;
        }

        IOFSObjects _itemsHandler = null;

        public IOFSObjects ItemsHandler
        {
            get { return _itemsHandler; }
            set { _itemsHandler = value; }
        }

        public News(IOFSObjects ItemsHandler, string Path)
        {
            this.Path = Path;
            this._itemsHandler = ItemsHandler;
            _itemsHandler.Path=Path;
        }



        public IOFSObject Get<T>(string id, string language)
        {
            throw new NotImplementedException();
        }

        public List<IOFSObject> Get(string id)
        {
            throw new NotImplementedException();
        }

        public List<IOFSObject> Get(ILoadingPolicy loadingPolicy)
        {
            throw new NotImplementedException();
        }

        public List<IOFSObject> GetAll<T>()
        {
            return ItemsHandler.GetAll<T>();
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
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IOFSObject DependantIOFSPagesObject
        {
            get { throw new NotImplementedException(); }
        }
    }
}
