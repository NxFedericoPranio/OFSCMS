using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataClasses.OFS.PhotoGallery
{
    public class Pic
    {
        public string Title { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string GalleryName { get; set; }
        public DateTime UploadDate { get; set; }
        public int Index { get; set; }
    }
}
