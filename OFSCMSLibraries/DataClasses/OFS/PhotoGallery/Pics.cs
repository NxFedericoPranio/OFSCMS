using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace DataClasses.OFS.PhotoGallery
{
    public class Pics : List<Pic>
    {
        private static Pics _instance = null;

        private void GetPics(string PathGallery, string PathThumbs)
        {
            //load all Photos
            Thubnail tb = new Thubnail();
            var dirs = new List<string>();
            int i = 0;
            if (System.IO.Directory.Exists(PathGallery))
            {
                dirs = ArraySlice(ScanDirForDir(PathGallery), 0, 2);
                if (dirs.Count > 0)
                {
                    dirs.Sort();
                    foreach (string dir in dirs)
                    {
                        int index = 0;
                        if (dir != "Thumbs")
                        {
                            tb.CreateThubnails(dir, PathGallery + "\\", PathThumbs + "\\");

                            string GalleryName = dir;
                            List<string> fnames = ScanDir(PathThumbs + "\\" + GalleryName);

                            XDocument descDoc = XDocument.Load(PathThumbs + "\\" + GalleryName + "\\" + "desc.xml");

                            foreach (string fname in fnames)
                            {
                                Pic ph = new Pic();
                                ph.Index = index;
                                ph.GalleryName = GalleryName;
                                FileInfo fi = new System.IO.FileInfo(fname);
                                ph.FileName = fi.Name;
                                if (fi.Extension.ToUpper() != ".XML")
                                {
                                    var queryDesc = from images in descDoc.Elements("descriptions").Elements("image")
                                                    where images.Element("name").Value == new FileInfo(fname).Name
                                                    select images;

                                    if (queryDesc.Any())
                                    {
                                        ph.Description = queryDesc.First().Element("text").Value;
                                    }
                                    this.Add(ph);
                                    index++;
                                }
                            }
                        }
                    }
                }
            }
        }

        private Pics()
        {
        }

        public static Gallery GetGallery(string GalleryName, int page, string pathGallery = null, int pagesize = 12, string pathThumbs = null)
        {
            if (_instance == null)
            {
                _instance = new Pics();
                _instance.GetPics(pathGallery, pathThumbs);
            }

            
            Gallery res = new Gallery();
            List<Pic> pics = _instance.Where(photo => photo.GalleryName.Equals(GalleryName, StringComparison.CurrentCultureIgnoreCase)).Select(Photo => Photo).Skip(page * pagesize).Take(pagesize).ToList();
            
            

            Pics resPics = new Pics();
            foreach (Pic pic in pics)
            {
                pic.Index = resPics.Count;
                resPics.Add(pic);
            }

            res.Pics = resPics;
            res.GalleryName = GalleryName;
            res.TotalCount = _instance.Where(photo => photo.GalleryName == GalleryName).Count();
            res.TotalPages = (res.TotalCount / pagesize) + 1;
            return res;
        }



        private List<string> ScanDir(string dir)
        {
            List<string> result = new List<string>();
            string[] dirs = System.IO.Directory.GetFiles(dir);
            foreach (string f in dirs)
            {
                result.Add(f);
            }
            return result;

        }

        private List<string> ScanDirForDir(string dir)
        {
            List<string> result = new List<string>();
            string[] dirs = System.IO.Directory.GetDirectories(dir);
            foreach (string f in dirs)
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(f);
                result.Add(di.Name);
            }
            return result;

        }

        private List<string> ArraySlice(List<string> List, int index1, int index2)
        {
            return List;
        }
    }
}
