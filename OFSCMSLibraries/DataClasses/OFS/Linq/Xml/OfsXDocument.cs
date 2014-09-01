using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.Reflection;
using DataClasses.DataModel.Generic;


namespace DataClasses.OFS.Linq.Xml
{
    public class OfsXDocument : XDocument
    {
        private static bool CheckFile(string uri)
        {
            if (uri == null || uri == string.Empty)
                return false;
            if (!System.IO.File.Exists(uri))
                return false;
            return true;
        }

        private static  string GetFileName(string path, string id, string culture)
        {
            if (!path.EndsWith("\\"))
                path += "\\";

            return string.Format("{0}{1}{2}.xml", path, id, culture);
        }
      


        private static bool CreateResourceFile(string uri)
        {
            try
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(uri);
                System.IO.DirectoryInfo di = fi.Directory;
                bool created = false;
                if (!di.Exists)
                {
                    di.Create();
                }
                if (!fi.Exists)
                {
                    fi.Create();
                    created = true;
                }

                if (created)
                {
                    XDocument xml = OfsXDocument.Load(uri);
                    XElement root = new XElement("ROOT");
                    xml.Add(root);
                    xml.Save(uri);
                    return true;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static XDocument Load(string uri)
        {
            if(!CheckFile(uri))
                return null;
            return XDocument.Load(uri);
        }

        public new void Save(string uri)
        {
            CreateResourceFile(uri);
            base.Save(uri);
        }


        public static int NewID(string fileName, string nodeName)
        {
            XDocument xml = XDocument.Load(fileName);
            IEnumerable<XElement> Root = xml.Elements("ROOT");

            if (Root.Any())
            {
                if (Root.First().Elements("nodeName").Count() > 0)
                {
                    IEnumerable<XElement> PagineAppo = Root.First().Elements("CONTENT");
                    return Convert.ToInt32(PagineAppo.Attributes("id").Max(l => int.Parse(l.Value)) + 1);
                }
                else
                {
                    return 1;
                }
            }

            throw new ApplicationException("File of content not ready");

        }


        public static IEnumerable<XElement> GetXmlElements(string fileName, string nodeName, IOFSObject ofsObject, bool deletedObject = false)
        {
            XDocument doc = XDocument.Load(fileName);

            var query = from objects in doc.Element("ROOT").Elements(nodeName)
                        where Convert.ToInt32(objects.Attribute("id").Value) == ofsObject.Id
                        && objects.Attribute("language").Value == ofsObject.Culture
                        && (deletedObject = true || (Convert.ToBoolean(objects.Element("DELETED")) == false))
                        select objects;
            return query;
        }

        public static List<IOFSObject> Get<T>(string path, string id, System.Globalization.CultureInfo language = null)
        {
            //MethodInfo getNewInst = T.GetMethod("GetNewIstance");
            Type typ = typeof(T);

            if (!(typ is IOFSObject))
                throw new ApplicationException("T is not an IOFSObject");

            string fileName = GetFileName(path, id, language.Name);

            ConstructorInfo magicConstructor = typ.GetConstructor(Type.EmptyTypes);
            

            DataClasses.OFS.Linq.Xml.OfsXDocument doc = (DataClasses.OFS.Linq.Xml.OfsXDocument)DataClasses.OFS.Linq.Xml.OfsXDocument.Load(fileName);
            if (doc != null)
            {
                var query = from items in doc.Elements("ROOT")
                            select items;

                
                List<IOFSObject> res = new List<IOFSObject>();

                foreach (XElement xItem in query)
                {
                    IOFSObject obj = (IOFSObject)magicConstructor.Invoke(new object[] { });
                    //obj.GetItemFronXML(xItem, ref obj);
                    res.Add(obj);
                }

                return res;
            }
            else
            {
                //pagina di elemento inesistente
            }

            //pagina di elemento inesistente
            return null;
        }

    }
}