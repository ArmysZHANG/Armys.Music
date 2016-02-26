using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Armys.MusicDal;

namespace Armys.MusicSystemUI.Controllers
{
    public class OrganizationManagementController : Controller
    {
        // GET: OrganizationManagement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SecurityKeys()
        {
            return View();
        }

        /// <summary>
        /// 用户组编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit()
        {
            return View();
        }
        /// <summary>
        /// 权限分配
        /// </summary>
        /// <returns>返回顶级菜单</returns>
        public ActionResult Tags(int groupId)
        {
            ViewBag.group_Id = groupId;
            var result = new SysUserDal().GetAllActiveFunction(groupId);
            return View(result);
        }

        /// <summary>
        /// 更改用户组权限
        /// </summary>
        /// <param name="authorityModel">状态</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Tags(sys_authority authorityModel)
        {
            var result = new SysUserGroupDal().UpdateTags(authorityModel);
            return Json(result);
        }
        /// <summary>
        /// 根据菜单编号获取子菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetAllChildMenu(int menuId)
        {
            var result = new SysUserDal().GetAllChildMenu(menuId);
            return Json(result);
        }
    }
}