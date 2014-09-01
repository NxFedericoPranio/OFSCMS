using DataClasses.DataModel.Calendar;
using DataClasses.DataModel.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OFSMVC.Controllers
{
    public class CalendarClientController : OFSCore.Base.ControllerBase
    {
        //
        // GET: /News/
        string pathNews = string.Empty;
        OFSObjects context = new OFSCalendarXml(OFSCore.Folders.CalendarFolder);

        public ActionResult GetNumerOfEvent()
        {
            var news = context.GetAll<OFSEvent>();
            ActionResult view = Json(news.Count(), JsonRequestBehavior.AllowGet);
            base.ModelCount = news.Count();
            return view;
        }

        public ActionResult ListOfEventsAjax(int Page)
        {
            var news = context.GetAll<OFSEvent>().Skip(Page * PageSize).Take(PageSize).OrderByDescending(e => ((OFSEvent)e).Date);
            ActionResult view = Json(news, JsonRequestBehavior.AllowGet);
            base.ModelCount = news.Count();
            return view;
        }


        public ActionResult ListOfEvents(int _escaped_fragment_ = 0)
        {
            SetAngularJsValues();
            var news = context.GetAll<OFSEvent>().Skip(_escaped_fragment_ * PageSize).OrderByDescending(e => ((OFSEvent)e).Date).Take(PageSize).ToList();
            ActionResult view = View(news);
            base.ModelCount = news.Count();
            return view;
        }

    }
}
