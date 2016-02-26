using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Armys.MusicDal;
using Armys.MusicSystemUI.Models;
using Armys.MusicTool;

namespace Armys.MusicSystemUI.Controllers
{
    [LoginAuthorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var userInfo = new Cache().GetCookie("userInfo");
            if (userInfo != null)
            {
                int userId = Convert.ToInt32(userInfo.Values["Id"]);
                ViewBag.TopMenu = new SysUserDal().GetUserFunction(userId);
            }
            return View();
        }

        /// <summary>
        /// 根据菜单编号获取子菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public JsonResult GetChildMenu(int menuId)
        {
            var userInfo = new Cache().GetCookie("userInfo");
            int groupId = Convert.ToInt32(userInfo.Values["GroupId"]);
            var result = new SysUserDal().GetChildMenu(menuId, groupId);
            return Json(result);
        }
    }
}