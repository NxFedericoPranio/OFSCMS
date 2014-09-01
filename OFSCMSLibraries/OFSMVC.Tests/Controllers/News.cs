using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataClasses.DataModel.News;

namespace OFSMVC.Tests.Controllers
{
    [TestClass]
    public class News
    {
        [TestMethod]
        public void TestNewscreation()
        {

            OFSNewsXml pages = new OFSNewsXml(@"d:\Documenti\Lavoro\OFS\OFSMVC\App_Data\News");
            OFSNew page = new OFSNew();
            int pagecount = pages.Items.Count;
            page.Content = "<h2>Fottiti òòòò !!!!</h2>";
            page.Css = "ciccio.css";
            page.UrlMap = "ciao.html";
            page.Culture = System.Globalization.CultureInfo.CurrentCulture.Name;
            page.Js = "pippo.js";
            page.Keywords = "io tu egli noi voi essi";
            page.Parent = 0;
            page.Title = "Titolo";

            Assert.IsTrue(pages.Save(page));

        }
    }
}
