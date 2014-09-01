using DataClasses.DataModel.Generic;
using DataClasses.OFS.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataClasses.DataModel.Orders
{
    public class OrdersXml: OFSObjects
    {
         Serializator serializator = new Serializator();
        OFSObjectsXml baseObjectsManager = new OFSObjectsXml();

        public OrdersXml(string path)
        {
            this.Path = path;
            Items = new List<IOFSObject>();
        }

        public override string Path
        {
            get
            {
                return baseObjectsManager.Path;
            }
            set{
                baseObjectsManager.Path = value;
            }
        }

        public override IOFSObject Get<T>(string id, string language)
        {
            return baseObjectsManager.Get<T>(id, language);            
        }

        public override List<IOFSObject> Get(string id)
        {

            return baseObjectsManager.Get(id);

        }

        public override bool Save(IOFSObject theEvent)
        {
            return baseObjectsManager.Save(theEvent);
        }


        public override bool Delete<T>(IOFSObject theEvent)
        {
            return baseObjectsManager.Delete<T>(theEvent);
        }




        public override List<IOFSObject> Items
        {
            get;
            set;
        }


        #region Private Methods

        

        private List<IOFSObject> GetObjects(IOFSObject obj, bool deletedObject = false)
        {
            List<IOFSObject> resultappo = new List<IOFSObject>();
            List<IOFSObject> result = new List<IOFSObject>();
            resultappo = baseObjectsManager.GetObjects<Order>(obj, deletedObject);
            foreach (IOFSObject ofsObj in resultappo)
            {
                result.Add((IOFSObject)ofsObj);
            }
            return result;
        }

      

       

        #endregion



        public new IOFSObject DependantIOFSPagesObject
        {
            get { throw new NotImplementedException(); }
        }


        public override List<IOFSObject> Get(ILoadingPolicy loadingPolicy)
        {
            throw new NotImplementedException();
        }

        public override List<IOFSObject> GetAll<T>()
        {
            DirectoryInfo di = new DirectoryInfo(Path);
            List<IOFSObject> result = new List<IOFSObject>();
            foreach (FileInfo fi in di.GetFiles("*.xml"))
            {

                IOFSObject eventObj = (IOFSObject)serializator.DeserializeObject(fi.FullName, typeof(T));
                result.Add(eventObj);
            }
            Items = result;
            return result;
        }
    }
}
