using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataClasses.DataModel.Menu
{
    [Serializable]
    [XmlRoot("OFSMenuChildren")]
    public class OFSMenuChildren
    {
        [XmlElement(Type = typeof(OFSMenu))]
        public ArrayList Children
        {
            get;
            set;
        }

        public bool HasOneOrMoreChildren
        {
            get {
                foreach (var c in Children)
                {
                    if (!((OFSMenu)c).Deleted)
                        return true;
                }
                return false;
            }
        }

        public OFSMenuChildren()
        {
            Children = new ArrayList();
        }
    }
}
