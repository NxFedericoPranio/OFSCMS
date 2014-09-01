using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataClasses.DataModel.Pages;
using DataClasses.DataModel.Menu;

namespace OFSMVC.Tests.Controllers
{
    [TestClass]
    public class OfsXDocumentTest
    {
        [TestMethod]
        public void TestXExtension()
        {
            System.Xml.Linq.XDocument xDoc = DataClasses.OFS.Linq.Xml.OfsXDocument.Load("");
            Assert.AreEqual(xDoc, null);
        }


        [TestMethod]
        public void TestPagecreation()
        {

            OFSPagesXml pages = new OFSPagesXml(@"d:\Documenti\Visual Studio 11\Projects\OFS\OFSMVC\App_Data\Pages");
            OFSPage page = new OFSPage();
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

        [TestMethod]
        public void TestModify()
        {

            OFSPagesXml pages = new OFSPagesXml(@"d:\Documenti\Visual Studio 11\Projects\OFS\OFSMVC\App_Data\Pages");
            OFSPage page = new OFSPage();
            int pagecount = pages.Items.Count;
            page.Id = 2;
            page.Content = "<h2>Fottiti òòòò !!!!3</h2>";
            page.Css = "ciccio2.css";
            page.UrlMap = "ciao.html";
            page.Culture = System.Globalization.CultureInfo.CurrentCulture.Name;
            page.Js = "pippo.js";
            page.Keywords = "io tu egli noi voi ess3i";
            page.Parent = 0;
            page.Title = "Titolo3";

            Assert.IsTrue(pages.Save(page));

        }

        [TestMethod]
        public void TestGetPage()
        {

            OFSPagesXml pages = new OFSPagesXml(@"d:\Documenti\Visual Studio 11\Projects\OFS\OFSMVC\App_Data\Pages");
            pages.Get<OFSPage>("2","it-it");

            //Assert.IsTrue(pages.Save(page));

        }

        [TestMethod]
        public void TestAddMenu()
        {
            int chidre1 = 0;
            OFSMenuesXml menues = new OFSMenuesXml(@"d:\Documenti\Visual Studio 11\Projects\OFS\OFSMVC\App_Data\Menues");
            OFSMenu menu = new OFSMenu();
            menu.Culture = "it-it";
            menu.HRef = "www.pranio.it";
            menu.IsVisible = true;
            menu.PageId = 2;
            menu.PageOwnerId = 2;
            menu.PageRefId = 2;
            menu.Parent = 0;
            menu.Text = "Menu 1";

            OFSMenu menu1 = new OFSMenu();
            menu1.Culture = "it-it";
            menu1.HRef = "www.cc.it";
            menu1.IsVisible = true;
            menu1.PageId = 2;
            menu1.PageOwnerId = 2;
            menu1.PageRefId = 2;
            menu1.Parent = 1;
            menu1.Text = "Menu 1.1";

            OFSMenu menu2 = new OFSMenu();
            menu2.Culture = "it-it";
            menu2.HRef = "www.cc.it";
            menu2.IsVisible = true;
            menu2.PageId = 2;
            menu2.PageOwnerId = 2;
            menu2.PageRefId = 2;
            menu2.Parent = 1;
            menu2.Text = "Menu 1.2";

            
            menu.MenuChildren.Children.Add(menu1);
            menu.MenuChildren.Children.Add(menu2);

            Assert.IsTrue(menues.Save(menu));

        }

        [TestMethod]
        public void TestGetMenu()
        {

            OFSMenuesXml menues = new OFSMenuesXml(@"d:\Documenti\Visual Studio 11\Projects\OFS\OFSMVC\App_Data\Menues");
            menues.Get<OFSMenu>("1", "it-it");

            //Assert.IsTrue(pages.Save(page));

        }
    }
}
