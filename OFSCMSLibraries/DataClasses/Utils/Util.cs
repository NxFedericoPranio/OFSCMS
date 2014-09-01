using DataClasses.DataModel.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataClasses.Utils
{
    public class Util
    {
        public static string GetFileName(IOFSObject obj, string path)
        {
            if (!path.EndsWith("\\"))
                path += "\\";

            return string.Format("{0}{1}{2}.xml", path, Convert.ToString(obj.Id).PadLeft(8, '0'), obj.Culture);
        }

        public static List<string> GetFileNames(string path, string id = null)
        {
            if (!path.EndsWith("\\"))
                path += "\\";

            string pref;
            if (id != null)
            {
                pref = string.Format("{0}{1}", path, id);
            }
            else
            {
                pref = string.Empty;
            }

            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] fii = di.GetFiles("*.xml");

            List<string> lf = null;
            if (pref != string.Empty)
            {
                lf = fii.Where(fi => fi.Name.StartsWith(pref)).Select(fi => fi.Name).ToList();
            }
            else
            {
                lf = fii.Where(fi => fi.Name.StartsWith(pref)).Select(fi => fi.FullName).ToList();
            }

            return lf;
        }

        internal static int NewID(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] fii = di.GetFiles("*.xml");

            if (fii.Count() == 0)
                return 1;

            int id = 0;

            foreach (FileInfo fi in fii)
            {
                XDocument xml = XDocument.Load(fi.FullName);
                //IEnumerable<XElement> Root = xml.Elements("ROOT");
                IEnumerable<XElement> Root = xml.Elements();

                if (Root.Any())
                {
                    int idappo = Convert.ToInt32(Root.Attributes("id").First().Value);
                    id = idappo > id ? idappo : id;
                }

            }
            if (id > 0)
                return id + 1;

            throw new ApplicationException("Unable to determine a valid Page id");

        }
    }


}
