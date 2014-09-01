using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace DataClasses.OFS.PhotoGallery
{
    public class Galleries : List<string>
    {
        public Galleries(string pathGallery)
        {
            foreach (DirectoryInfo di in new DirectoryInfo(pathGallery).GetDirectories())
            {
                if (di.Name.ToUpper() != "THUMBS")
                {
                    this.Add(di.Name);
                }
            }
        }
    }
}
