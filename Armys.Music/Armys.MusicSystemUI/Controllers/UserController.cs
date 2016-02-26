using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Armys.MusicTool;
using Armys.MusicDal;
using Armys.MusicSystemUI.Models;

namespace Armys.MusicSystemUI.Controllers
{
    public class UserController : Controller
    {
        //用户登录
        public ActionResult Login()
        {
            return View();
        }
        //用户登录
        [HttpPost]
        public JsonResult Login(sys_userinfo users, string rememberPassword)
        {
            users.password = new EncryptHelper().Encrypt(users.password, new ReadSystemConfig().GetSystemConfig("SystemKey"));
            var result = new SysUserDal().GetUserInfo(users);
            if (result == null) return Json(false);
            //登录成功，保存用户基础信息！
            result.RememberPassword = rememberPassword;
            new SystemCache().SetLoginInfo(result);
            if (rememberPassword == "on") new SystemCache().SetLoginPwd(users.password, 7, "days");
            else new SystemCache().SetLoginPwd(users.password, 2, "hours");
            return Json(true);
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            var userInfo = new Cache().GetCookie("userInfo");
            if (userInfo.Values["RememberPassword"] != "on")
                new Cache().DelCookie("passwordSet");
            return RedirectToAction("Login");
        }

        /// <summary>
        /// 忘记密码
        /// </summary>
        /// <returns></returns>
        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult UserQuery(int? page, string searchValue = "")
        {
            ViewBag.searchValue = searchValue;
            var result = new SysUserDal().GetAllUser(searchValue, page ?? 1);
            return View(result);
        }

        /// <summary>
        /// 用户组
        /// </summary>
        /// <returns></returns>
        public ActionResult UserGroup(int? page, string searchValue = "")
        {
            ViewBag.searchValue = searchValue;
            var result = new SysUserDal().GetAllUserGroup(searchValue, page ?? 1);
            return View(result);
        }

        /// <summary>
        /// 更新用户组状态
        /// </summary>
        /// <param name="groupId">组编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateStatus(int groupId, bool status)
        {
            var result = new SysUserDal().UpdateStatus(groupId, status);
            return Json(result);
        }

        /// <summary>
        /// 新增用户组
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUserGroup()
        {
            return View();
        }
    }
}