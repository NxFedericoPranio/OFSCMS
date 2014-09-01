using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataClasses.OFS.PhotoGallery
{
    public class Gallery
    {
        public Pics Pics { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public string GalleryName { get; set; }
    }
}
