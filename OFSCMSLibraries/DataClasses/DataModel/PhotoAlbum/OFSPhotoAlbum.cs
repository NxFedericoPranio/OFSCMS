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
    public class OFSPhotoAlbum : IOFSObject
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

        public ArrayList Pics { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public string GalleryName { get; set; }


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
