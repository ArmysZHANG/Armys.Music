using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Armys.MusicSystemUI.Models
{
    //统计页面
    public class StatisticsController : Controller
    {
        // 主页
        public ActionResult Index()
        {
            return View();
        }
    }
}