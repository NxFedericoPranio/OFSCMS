using DataClasses.DataModel.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFSCore.HtmlElements
{
    public static class NewsBox
    {
        public static string GetHtml(string Path, int NewsPage=0)
        {
            StringBuilder res = new StringBuilder();
            res.Append("<!-- slider text article start -->\r\n" +
          "<div id=\"containerNews\"><div class=\"freshdesignweb\">\r\n" +
               "<article class=\"grid_3  carousel-article\">\r\n" +
                   "<div class=\"caroufredsel_wrapper\">\r\n" +
                   "<ul id=\"foo3\" class=\"carousel-li\">\r\n");

            List<DataClasses.DataModel.Generic.IOFSObject> news = new OFSNewsXml(Path).GetAll<OFSNew>().Take(10).ToList();
            foreach (OFSNew info in news)
            {
                res.Append("<li><h2>\r\n");
                res.Append(info.Title +"<br /><p>"+ info.Content+"<br/>&nbsp;</p>");
                res.Append("</h2></li>\r\n");

                //res.Append("<li><p>\r\n");
                //res.Append(info.Title+"-");
                //res.Append(info.Content);
                //res.Append("</p></li>\r\n");
            }
            res.Append("</ul></div>\r\n");
            res.Append("<!-- slider text article start -->\r\n" +
                       "<div class=\"clearfix\"></div>\r\n" +
                       "<div style=\"display: block;\" class=\"carousel-pagination\" id=\"foo3_pag\"><a class=\"selected\" href=\"#\">\r\n");
            foreach (OFSNew info in news)
            {
                res.Append(string.Format("<span>{0}</span></a><a class=\"\" href=\"#\">\r\n", news.IndexOf(info)));
            }

           res.Append("</article><!-- slider text article end -->\r\n");

           res.Append("<script>\r\n" +
               "$(\"#foo3\").carouFredSel({\r\n" +
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
           "var get_container = document.getElementById('containerNews');\r\n" +
           "get_container.style.height =  get_height1 + 'px';\r\n" +
           "</script>\r\n"
            );
            return res.ToString();
        }
    }
}
