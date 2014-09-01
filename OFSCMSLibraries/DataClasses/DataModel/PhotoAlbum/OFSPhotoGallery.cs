using DataClasses.DataModel.Generic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DataClasses.DataModel.PhotoAlbum
{
    [XmlRoot("ROOT")]
    public class OFSPhotoGallery : IOFSObject
    {
        [XmlAttribute("id")]
        public int Id
        {
            get;
            set;
        }


        [XmlAttribute("culture")]
        public string Culture
        {
            get;
            set;
        }

        string Name { get; set; }
        public ArrayList Albums { get; set; }



        public int PageId
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

        public int IdSection
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

        public int IdSite
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

        public DateTime DateAdded
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

        public DateTime DateModified
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

        public bool Deleted
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

        public DateTime DateDeleted
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

        public IOFSObject GetNewIstance()
        {
            throw new NotImplementedException();
        }
    }
}
