using System;
using System.Configuration;
using System.Linq;
using System.Text;

namespace OFSCore
{
    public static class Folders
    {

        public static string BaseFolder
        {
            get { return DataClasses.OFS.Folders.BaseFolder; }
        }
        public static string PageFolder
        {
            get { return DataClasses.OFS.Folders.PageFolder; }
        }

        public static string GalleryFolder
        {
            get { return DataClasses.OFS.Folders.GalleryFolder; }
        }

        public static string MenuFolder
        {
            get { return DataClasses.OFS.Folders.MenuFolder; }
        }

        public static string NewsFolder
        {
            get { return DataClasses.OFS.Folders.NewsFolder; }
        }

        public static string CalendarFolder
        {
            get { return DataClasses.OFS.Folders.CalendarFolder; }
        }

        public static string WebRoot
        {
            get { return DataClasses.OFS.Folders.WebRoot; }
        }

        public static string TextsFolder
        {
            get { return DataClasses.OFS.Folders.TextsFolder; }
        }

        public static string UserFolder
        {
            get { return DataClasses.OFS.Folders.UserFolder; }
        }

        public static string BlogFolder
        {
            get { return DataClasses.OFS.Folders.BlogFolder; }
        }

        public static string MailAttachments
        {
            get { return DataClasses.OFS.Folders.MailAttachments; }
        }

        public static string Mails
        {
            get { return DataClasses.OFS.Folders.Mails; }
        }

        public static string Orders
        {
            get { return DataClasses.OFS.Folders.Orders; }
        }

        public static string GuestBook
        {
            get { return DataClasses.OFS.Folders.GuestBook; }
        }
    }
}
