using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using DataClasses.OFS.Serialization;
using DataClasses.DataModel.Pages;
using DataClasses.DataModel.Generic;

namespace DataClasses.DataModel.Menu
{
    public class OFSMenuesXml : OFSObjects
    {

        Serializator serializator = new Serializator();
        string itemNodeName = "MENU";

        OFSObjectGenericForManyInOneFile baseObjectsManager = new OFSObjectGenericForManyInOneFile();

        public OFSMenuesXml(string path)
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

        public override bool Save(IOFSObject menuItem)
        {
            return baseObjectsManager.Save(menuItem);
        }


        public override bool Delete<T>(IOFSObject menuItem)
        {
            return baseObjectsManager.Delete<T>(menuItem);
        }




        public override List<IOFSObject> Items
        {
            get;
            set;
        }


        #region Private Methods

        

        //private List<IOFSObject> GetObjects(IOFSObject obj, bool deletedObject = false)
        //{
        //    List<IOFSObject> resultappo = new List<IOFSObject>();
        //    List<IOFSObject> result = new List<IOFSObject>();
        //    resultappo = baseObjectsManager.GetObjects<OFSMenu>(obj, deletedObject);
        //    foreach (IOFSObject ofsObj in resultappo)
        //    {
        //        result.Add((IOFSObject)ofsObj);
        //    }
        //    return result;
        //}

      

       

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

                IOFSObject eventObj = (IOFSObject)serializator.DeserializeObject(fi.FullName, typeof(OFSMenu));
                result.Add(eventObj);
            }
            Items = result;
            return result;
        }


        public OFSMenu GetAllMenu()
        {
            DirectoryInfo di = new DirectoryInfo(Path);
            List<IOFSObject> result = new List<IOFSObject>();
            foreach (FileInfo fi in di.GetFiles("*.xml"))
            {

                IOFSObject eventObj = (IOFSObject)serializator.DeserializeObject(fi.FullName, typeof(OFSMenu));
                result.Add(eventObj);
            }
            Items = result;
            return (OFSMenu)result.FirstOrDefault();
        }
    }
}