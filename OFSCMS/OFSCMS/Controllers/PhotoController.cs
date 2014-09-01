using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OFSMVC.Controllers
{
    public class PhotoController : OFSCore.Base.ControllerBase
    {
        //
        // GET: /Photo/
        public static string PathGallery = OFSCore.Folders.GalleryFolder.EndsWith("\\") ? OFSCore.Folders.GalleryFolder : OFSCore.Folders.GalleryFolder + "\\";
        public static string PathThumbnails = PathGallery + "Thumbs";

        public ActionResult Gallery(string Name, int Page)
        {
            SetAngularJsValues();
            return View(DataClasses.OFS.PhotoGallery.Pics.GetGallery(Name, Page, PathGallery, PageSize, PathThumbnails));
        }

        public ActionResult GalleryAjax(string Name, int Page)
        {
            return Json(DataClasses.OFS.PhotoGallery.Pics.GetGallery(Name, Page, PathGallery, PageSize, PathThumbnails), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GalleryList()
        {
            return PartialView(new DataClasses.OFS.PhotoGallery.Galleries(PathGallery));
        }

        public ActionResult GalleryListAjax()
        {
            return Json(new DataClasses.OFS.PhotoGallery.Galleries(PathGallery), JsonRequestBehavior.AllowGet);
        }

    }
}
