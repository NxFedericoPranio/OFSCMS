using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml.Linq;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DataClasses.OFS.PhotoGallery
{
    public class Thubnail
    {
        /// <summary>
        /// Genera e salva le thubnails
        /// </summary>
        /// <returns>true</returns>
        public bool GetThubnail2(string ImageName, string ThubnailPath, int width, int height)
        {
            try
            {
                int widthAppo, heightAppo;
                widthAppo = width;
                heightAppo = height;
                string file = ImageName;
                System.Drawing.Image image = System.Drawing.Image.FromFile(file);
                if (height == 0)
                    heightAppo = (widthAppo * image.Height / image.Width);
                if (width == 0)
                    widthAppo = (heightAppo * image.Width / image.Height);

                Bitmap thump = new Bitmap(widthAppo, heightAppo);
                Graphics graphics = Graphics.FromImage(thump);
                Matrix transform = new Matrix();

                float scale = 1;
                transform.Scale(scale, scale, MatrixOrder.Append);
                graphics.SetClip(new Rectangle(0, 0, width, height));
                graphics.Transform = transform;
                graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
                graphics.DrawImage(image, 0, 0, image.Width, image.Height);


                ImageCodecInfo[] Info = ImageCodecInfo.GetImageEncoders();
                EncoderParameters Params = new EncoderParameters(1);
                Params.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                thump.Save(ThubnailPath, Info[1], Params);


                thump.Dispose();
                graphics.Dispose();

                
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetThubnail(string ImageName, string ThubnailPath, int witdth, int height)
        {
            try
            {
                decimal widthAppo, heightAppo;
                widthAppo = witdth;
                heightAppo = height;
                string file = ImageName;
                System.Drawing.Image image = System.Drawing.Image.FromFile(file);
                if (height == 0)
                    heightAppo = (widthAppo *
                        Convert.ToDecimal(Convert.ToDecimal(image.Height) /
                        Convert.ToDecimal(image.Width)));
                if (witdth == 0)
                    widthAppo = (heightAppo *
                        Convert.ToDecimal(Convert.ToDecimal(image.Width) /
                        Convert.ToDecimal(image.Height)));

                // create the actual thumbnail image
                System.Drawing.Image thumbnailImage = image.GetThumbnailImage(
                    Convert.ToInt32(widthAppo),
                    Convert.ToInt32(heightAppo),
                    new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback),
                    IntPtr.Zero);

                // make a memory stream to work with the image bytes
                MemoryStream imageStream = new MemoryStream();

                // put the image into the memory stream
                thumbnailImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg);

                // make byte array the same size as the image
                byte[] imageContent = new Byte[imageStream.Length];

                // rewind the memory stream
                imageStream.Position = 0;

                // load the byte array with the image
                imageStream.Read(imageContent, 0, (int)imageStream.Length);

                // return byte array to caller with image type
                //Response.ContentType = "image/jpeg";
                //Response.BinaryWrite(imageContent);
                System.IO.FileInfo f = new FileInfo(ImageName);
                FileStream fs = new FileStream(ThubnailPath, FileMode.Create);

                byte[] data = imageStream.ToArray();
                fs.Write(data, 0, data.Length);
                fs.Close();
                fs.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// Required, but not used
        /// </summary>
        /// <returns>true</returns>
        public bool ThumbnailCallback()
        {
            return true;
        }

        public void CreateThubnails(string album, string pathImages, string pathThumbs)
        {
            //string path = ScanDirForDir(Server.MapPath("images");
            var dirs = new List<string>();
            var images = Util.ScanDirForDir(pathImages);
            //dirs = Util.ArraySlice(images, 0, 2);
            Thubnail tn = new Thubnail();
            //foreach(string d in dirs){
            var files = Util.ArraySlice(Util.ScanDir(pathImages + album), 0, 2);
            {
                string d = album;
                foreach (string f in files)
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(f);
                    if (!System.IO.Directory.Exists(pathThumbs + d))
                        System.IO.Directory.CreateDirectory(pathThumbs + d);
                    if (!System.IO.File.Exists(pathThumbs + d + "\\" + fi.Name))
                    {
                        if (tn.GetThubnail(f, pathThumbs + d + "\\" + fi.Name, 0, 100))
                        {
                            //aggiorno il file
                            string xmlFileName = pathThumbs + d + "\\desc.xml";
                            if (!System.IO.File.Exists(xmlFileName))
                                CreateXMLFile(xmlFileName);
                            XDocument xml = XDocument.Load(xmlFileName);
                            XElement imagel = new XElement("image");

                            XElement namel = new XElement("name");
                            namel.Value = fi.Name;

                            XElement textel = new XElement("text");
                            textel.Value = "Descrizione dell'immaggine " + fi.Name;

                            imagel.Add(namel);
                            imagel.Add(textel);



                            xml.Element("descriptions").Add(imagel);
                            xml.Save(xmlFileName);
                        }
                    }
                }
                //}
            }
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        void CreateXMLFile(string filename)
        {
            XElement el = new XElement("descriptions");
            XDocument d = new XDocument();
            d.Add(el);
            d.Save(filename);
        }
    }


}