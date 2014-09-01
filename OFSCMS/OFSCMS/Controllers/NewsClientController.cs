using DataClasses.DataModel.Generic;
using DataClasses.DataModel.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OFSMVC.Controllers
{
    public class NewsClientController : OFSCore.Base.ControllerBase
    {
        //
        // GET: /News/
        string pathNews = string.Empty;
        IOFSObjects context = new OFSNewsXml(OFSCore.Folders.NewsFolder);

      

        public ActionResult ListOfNewsAjax(int Page)
        {
            var news = context.GetAll<OFSNew>().Skip(Page * PageSize).Take(PageSize).OrderByDescending(i=>i.Id);
            ActionResult view = Json(news, JsonRequestBehavior.AllowGet);
            base.ModelCount = news.Count();
            return view;
        }


        public ActionResult ListOfNews(int _escaped_fragment_ = 0)
        {
            SetAngularJsValues();
            var news = context.GetAll<OFSNew>().Skip(_escaped_fragment_ * PageSize).Take(PageSize).ToList();
            ActionResult view = View(news);
            base.ModelCount = news.Count();
            return view;
        }

    }
}
