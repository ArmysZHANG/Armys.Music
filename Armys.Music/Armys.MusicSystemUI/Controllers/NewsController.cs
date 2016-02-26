using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Armys.MusicSystemUI.Controllers
{
    /// <summary>
    /// 消息相关
    /// </summary>
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult SendEmail()
        {
            return View();
        }
    }
}