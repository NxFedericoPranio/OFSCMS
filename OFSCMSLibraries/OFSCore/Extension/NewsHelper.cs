using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFSCore.Extension
{
    public static class NewsHelper
    {
        public static string CaptureActionHtml<TController>(
           this TController controller,
            string FolderNews,
            int startId,
            int showNumber)
        {
            
            //var news = new DataClasses.OFS.News.News(new DataClasses.OFSPagesXml(FolderNews), FolderNews);
            //news.GetAll();
            //return news.;

            return "<p>News ciao</p>";
        }
    }
}
