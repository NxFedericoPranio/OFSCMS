using System;
using System.Configuration;
using System.Linq;
using System.Text;

namespace DataClasses.OFS
{
    public static class Folders
    {

        public static string BaseFolder
        {
            get { return ConfigurationManager.AppSettings["BaseFolder"]; }
        }
        public static string PageFolder
        {
            get { return ConfigurationManager.AppSettings["PageFolder"]; }
        }

        public static string GalleryFolder
        {
            get { return ConfigurationManager.AppSettings["GalleryFolder"]; }
        }

        public static string MenuFolder
        {
            get { return ConfigurationManager.AppSettings["MenuFolder"]; }
        }

        public static string NewsFolder
        {
            get { return ConfigurationManager.AppSettings["NewsFolder"]; }
        }

        public static string CalendarFolder
        {
            get { return ConfigurationManager.AppSettings["CalendarFolder"]; }
        }

        public static string WebRoot
        {
            get { return ConfigurationManager.AppSettings["WebRoot"]; }
        }

        public static string TextsFolder
        {
            get { return ConfigurationManager.AppSettings["TextsFolder"]; }
        }

        public static string UserFolder
        {
            get { return ConfigurationManager.AppSettings["UserFolder"]; }
        }

        public static string MailAttachments
        {
            get { return ConfigurationManager.AppSettings["MailAttachments"]; }
        }

        public static string Mails
        {
            get { return ConfigurationManager.AppSettings["Mails"]; }
        }


        public static string Orders
        {
            get { return ConfigurationManager.AppSettings["OrderFolder"]; }
        }

        public static string GuestBook
        {
            get { return ConfigurationManager.AppSettings["GuestBookFolder"]; }
        }

        public static string BlogFolder
        {
            get { return ConfigurationManager.AppSettings["BlogFolder"]; }
        }
    }
}
