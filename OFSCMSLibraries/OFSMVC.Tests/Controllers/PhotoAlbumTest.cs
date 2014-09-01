using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OFSMVC.Tests.Controllers
{
    [TestClass]
    public class PhotoAlbumTest
    {
        [TestMethod]
        public void TestLoad()
        {
            DataClasses.OFS.PhotoGallery.Gallery photos = DataClasses.OFS.PhotoGallery.Pics.GetGallery(
                "Assisi2012", 0, @"d:\inetpub\webs\pranioit\PhotoGallery", 10, @"d:\inetpub\webs\pranioit\PhotoGallery\Thumbs"
                );
        }
    }
}
