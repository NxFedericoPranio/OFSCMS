using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataClasses.OFS.Serialization;
using DataClasses.DataModel.Generic;

namespace DataClasses.Utils
{
    public class OfsFileHelper
    {

        Serializator serializator = new Serializator();

        public IOFSObject Get(string path, string id, string language)
        {

            IOFSObject obj = new GenericObject
            {
                Id = Convert.ToInt32(id),
                Culture = language
            };

            List<IOFSObject> objs = GetItems(path, obj);
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


        private List<IOFSObject> GetItems(string path, IOFSObject obj, bool deleted = false)
        {
            List<IOFSObject> result = new List<IOFSObject>();
            List<string> fileNames = null;
            IOFSObject objRes = null;


            if (obj.Culture == string.Empty)
            {
                fileNames = Util.GetFileNames(path, Convert.ToString(obj.Id));
            }

            string fileName = Utils.Util.GetFileName(obj, path);
            if (fileNames != null)
            {
                foreach (string filaNameAppo in fileNames)
                {
                    objRes = (IOFSObject)serializator.DeserializeObject(filaNameAppo, typeof(IOFSObject));
                    result.Add(objRes);
                }
            }
            else
            {
                objRes = (IOFSObject)serializator.DeserializeObject(fileName, typeof(IOFSObject));
                result.Add(objRes);
            }
            return result;

        }
    }
}
