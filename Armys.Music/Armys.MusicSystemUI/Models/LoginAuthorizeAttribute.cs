using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Armys.MusicTool;

namespace Armys.MusicSystemUI.Models
{
    public class LoginAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //获取Cookies中的Login
            var loginValidation = HttpContext.Current.Request.Cookies["passwordSet"];
            var userInfo = HttpContext.Current.Request.Cookies["userInfo"];
            if (loginValidation != null || userInfo != null) return;
            //页面跳转到 登录页面
            JsScriptHelper.AlertAndRedirect("登录超时，请重新登录", "/User/Login");
        }
    }
}