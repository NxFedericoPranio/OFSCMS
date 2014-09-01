using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.IO;
using DataClasses.OFS.Serialization;
using System.Security.Permissions;
using DataClasses.DataModel.Pages;

namespace DataClasses.DataModel.Generic
{
    public class OFSObjectsXml : IOFSObjectBase
    {
        internal OFSObjectsXml()
        {
        }

        public OFSObjectsXml(string Path)
        {
            this.Path = Path;
        }

        Serializator serializator = new Serializator();

        public string Path
        {
            get;
            set;
        }

        public IOFSObject Get<T>(string id, string language)
        {

            IOFSObject obj = new OFSObject
            {
                Id=Convert.ToInt32(id),
                Culture = language
            };

            List<IOFSObject> objs = GetObjects<T>(obj);
            if (objs.Any())
            {
                obj = objs.First();
                return obj;
            }
            else
            {
                //pagina di elemento inesistente
            }

            //pagina di elemento inesistente
            return null;

            
        }

        public List<IOFSObject> Get(string id)
        {

            List<string> fileNames;
            if (id != null)
            {
                fileNames = Utils.Util.GetFileNames(Path, id);
            }
            else
            {
                fileNames = Utils.Util.GetFileNames(Path);
            }
            List<IOFSObject> result = new List<IOFSObject>();

            foreach (string fileName in fileNames)
            {
                DataClasses.OFS.Linq.Xml.OfsXDocument doc = (DataClasses.OFS.Linq.Xml.OfsXDocument)DataClasses.OFS.Linq.Xml.OfsXDocument.Load(fileName);
                if (doc != null)
                {
                    IOFSObject page = (IOFSObject)serializator.DeserializeObject(fileName, typeof(OFSPage));

                        result.Add(page);
                }
                else
                {
                    //pagina di elemento inesistente
                }
            }
            return result;

        }

        public bool Save(IOFSObject item)
        {
            IOFSObject itemAppo = (IOFSObject)item;           

            try
            {

                if (itemAppo.Id <= 0)
                {
                    itemAppo.Id = Utils.Util.NewID(Path);
                    itemAppo.DateAdded = DateTime.Now;
                    itemAppo.DateModified = DateTime.Now;
                    itemAppo.Deleted = false;
                }
                else
                {
                    itemAppo.DateModified = DateTime.Now;
                }

                string fileName = Utils.Util.GetFileName(itemAppo, Path);

                DataClasses.OFS.Serialization.Serializator serializator = new OFS.Serialization.Serializator();
                serializator.SerializeObject(fileName, item);

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool Delete<T>(IOFSObject page)
        {
            string fileName = Utils.Util.GetFileName((IOFSObject)page, Path);
            try
            {
                XDocument doc = DataClasses.OFS.Linq.Xml.OfsXDocument.Load(fileName);

                List<IOFSObject> query = GetObjects<T>(page);
                foreach (IOFSObject currPage in query)
                {
                    currPage.Deleted = true;
                    currPage.DateDeleted = DateTime.Now;
                    serializator.SerializeObject(fileName, currPage);
                } 
                return true;
            }
            catch
            {
                return false;
            }
        }



        public List<IOFSObject> Items
        {
            get;
            set;
        }


        #region Private Methods

        

        internal List<IOFSObject> GetObjects<T>(IOFSObject obj, bool deletedObject = false)
        {
            string fileName = string.Empty;
            try
            {
                List<IOFSObject> result = new List<IOFSObject>();
                List<string> fileNames = null;
                IOFSObject pageRes = null;


                if (obj.Culture == string.Empty)
                {
                    fileNames = Utils.Util.GetFileNames(Path, Convert.ToString(obj.Id));
                }

                fileName = Utils.Util.GetFileName((IOFSObject)obj, Path);
                if (fileNames != null)
                {
                    foreach (string filaNameAppo in fileNames)
                    {
                        fileName = filaNameAppo;
                        pageRes = (IOFSObject)serializator.DeserializeObject(filaNameAppo, typeof(T));
                        result.Add(pageRes);
                    }
                }
                else
                {
                    //FileIOPermission filePerm = new FileIOPermission(FileIOPermissionAccess.AllAccess, fileName);
                    //filePerm.Assert();
                    pageRes = (IOFSObject)serializator.DeserializeObject(fileName, typeof(T));
                    result.Add(pageRes);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error in opening file é {0} --- {1}", fileName, ex.Message));
            }

        }

        internal void GetObjectsFronXML(XElement element, ref IOFSObject obj)
        {
            obj.Id = Convert.ToInt32(element.Attribute("id").Value);
            obj.Culture = element.Attribute("language").Value;
            obj.Deleted = Convert.ToBoolean(element.Element("DELETED").Value);
            obj.DateAdded = Convert.ToDateTime(element.Element("DATEADDED").Value);
            obj.DateModified = Convert.ToDateTime(element.Element("DATEMODIFIED").Value);
            obj.DateDeleted = Convert.ToDateTime(element.Element("DATEDELETED").Value);
        }

        private Uri GetUri(string uri){
            if(uri == null || uri== string.Empty || uri=="/")
                return null;
            else
                return new Uri(uri);
        }

        #endregion



        public IOFSObject DependantIOFSPagesObject
        {
            get { throw new NotImplementedException(); }
        }


        public List<IOFSObject> Get(ILoadingPolicy loadingPolicy)
        {
            throw new NotImplementedException();
        }

        public List<IOFSObject> GetAll()
        {
            return GetObjects<IOFSObject>(null).Where(a=>!a.Deleted).ToList();
        }
    }
}
