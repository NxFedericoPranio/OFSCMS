using DataClasses.DataModel.Calendar;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace OFSCore.HtmlElements
{
    public static class CalendarBox
    {
        public static string GetHtml(string Path, int NewsPage=0)
        {
            StringBuilder res = new StringBuilder();
            res.Append("<!-- slider text article start -->\r\n" +
          "<div id=\"containerEvents\"><div class=\"freshdesignweb\">\r\n" +
               "<article class=\"grid_3  carousel-article\">\r\n" +
                   "<div class=\"caroufredsel_wrapper\">\r\n" +
                   "<ul id=\"foo3evt\" class=\"carousel-li\">\r\n");

            List<DataClasses.DataModel.Generic.IOFSObject> events = new OFSCalendarXml(Path).GetAll<OFSEvent>().Take(5).ToList();
            foreach (OFSEvent evt in events)
            {
                res.Append("<li><h2>\r\n");
                res.Append(evt.Title +"<br />");
                res.Append("<p> Il giorno <span>" + evt.Date.ToString("D", new CultureInfo(OFSCore.LanguageManager.GetLanguage())) + "</span> alle ore <span>" + evt.Time.ToString("H:mm", new CultureInfo(OFSCore.LanguageManager.GetLanguage())) + "</span></p>");
                res.Append("<p>"+ evt.Description+"<br/>&nbsp;</p>");
                res.Append("</h2></li>\r\n");

                //res.Append("<li><p>\r\n");
                //res.Append(info.Title+"-");
                //res.Append(info.Content);
                //res.Append("</p></li>\r\n");
            }
            res.Append("</ul></div>\r\n");
            res.Append("<!-- slider text article start -->\r\n" +
                       "<div class=\"clearfix\"></div>\r\n" +
                       "<div style=\"display: block;\" class=\"carousel-pagination\" id=\"foo3evt_pag\"><a class=\"selected\" href=\"#\">\r\n");
            foreach (OFSEvent evt in events)
            {
                res.Append(string.Format("<span>{0}</span></a><a class=\"\" href=\"#\">\r\n", events.IndexOf(evt)));
            }

           res.Append("</article><!-- slider text article end -->\r\n");

           res.Append("<script>\r\n" +
               "$(\"#foo3evt\").carouFredSel({\r\n" +
                   "items: 1,\r\n" +
                   "auto: true,\r\n" +
                   "scroll: 1,\r\n" +
                   "pagination  : \"#foo3_pag\"\r\n" +
               "});\r\n" +
           "</script>\r\n" +
           "</div></div>\r\n" +
           "<script type=\"text/javascript\">\r\n" +
           "var get_height = window.innerHeight;\r\n" +
           "var get_height1 =  get_height - 25;\r\n" +
           "var get_container = document.getElementById('containerEvents');\r\n" +
           "get_container.style.height =  get_height1 + 'px';\r\n" +
           "</script>\r\n"
            );
            return res.ToString();
        }
    }
    
}
