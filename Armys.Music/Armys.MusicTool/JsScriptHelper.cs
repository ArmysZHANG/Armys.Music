using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Armys.MusicTool
{
    public class JsScriptHelper
    {
        /// <summary>
        /// 弹出消息框并且转向到新的URL
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="toUrl">连接地址</param>
        public static void AlertAndRedirect(string message, string toUrl)
        {
            string js = "<script language=javascript>alert('{0}');window.location.replace('{1}')</script>";
            HttpContext.Current.Response.Write(string.Format(js, message, toUrl));
            HttpContext.Current.Response.End();
        }
    }
}
