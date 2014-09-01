using DataClasses.DataModel.Blog;
using DataClasses.DataModel.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OFSCMS.Controllers
{
    public class BlogClientController : OFSCore.Base.ControllerBase
    {
        //
        // GET: /BlogClient/

        string pathNews = string.Empty;
        IOFSObjects context = new OFSPostsXml(OFSCore.Folders.NewsFolder);

        public ActionResult ListOfPostAjax(int Page)
        {
            var news = context.GetAll<OFSPost>().Skip(Page * PageSize).Take(PageSize).OrderByDescending(i => i.Id);
            ActionResult view = Json(news, JsonRequestBehavior.AllowGet);
            base.ModelCount = news.Count();
            return view;
        }


        public ActionResult ListOfPost(int _escaped_fragment_ = 0)
        {
            SetAngularJsValues();
            var news = context.GetAll<OFSPost>().Skip(_escaped_fragment_ * PageSize).Take(PageSize).ToList();
            ActionResult view = View(news);
            base.ModelCount = news.Count();
            return view;
        }
    }
}
