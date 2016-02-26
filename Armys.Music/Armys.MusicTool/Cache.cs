using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//缓存操作类引入的命名空间
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace Armys.MusicTool
{
    /// <summary>
    /// 缓存操作类
    /// </summary>
    public class Cache
    {
        /// <添加Cookie> 
        /// 添加Cookie 
        /// </添加Cookie>
        /// <param name="cookie"></param> 
        public void AddCookie(HttpCookie cookie)
        {
            var response = HttpContext.Current.Response;
            //指定客户端脚本是否可以访问[默认为false] 
            cookie.HttpOnly = true;
            //指定统一的Path，比便能通存通取 
            cookie.Path = "/";
            //设置跨域,这样在其它二级域名下就都可以访问到了 //
            //cookie.Domain = "www.armys.top"; 
            response.AppendCookie(cookie);
        }

        /// <设置Cookie子键的值 >
        /// 设置Cookie子键的值 
        /// </设置Cookie子键的值 >
        /// <param name="cookieName">缓存对象名称</param>
        /// <param name="key">缓存键值</param>
        /// <param name="value">缓存值</param>
        /// <param name="hours">时间</param>
        /// <param name="unit">天或者小时为单位"hours"或者"days"</param>
        public void SetCookie(string cookieName, string key, string value, double hours, string unit)
        {
            var request = HttpContext.Current.Request;
            {
                var cookie = request.Cookies[cookieName];
                if (cookie == null) return;
                if (!string.IsNullOrEmpty(key) && cookie.HasKeys)
                    cookie.Values.Set(key, value);
                else if (!string.IsNullOrEmpty(value))
                    cookie.Value = value;
                cookie.Expires = "days" == unit ? DateTime.Now.AddDays(hours) : DateTime.Now.AddHours(hours);
                AddCookie(cookie);
            }
        }

        /// <获得Cookie > 
        /// 获得Cookie 
        /// </获得Cookie>
        /// <param name="cookieName"></param> 
        /// <returns></returns>
        public HttpCookie GetCookie(string cookieName)
        {
            var request = HttpContext.Current.Request;
            return request.Cookies[cookieName]; 
        }

        /// <summary>
        /// 删除Cookie
        /// </summary>
        /// <param name="cookieName"></param>
        public void DelCookie(string cookieName)
        {
            var response = HttpContext.Current.Response;
            {
                var cookie = response.Cookies[cookieName];
                if (cookie == null) return;
                cookie.Expires = DateTime.Now.AddDays(-1);
                response.SetCookie(cookie);
            }
        }
    }
}
