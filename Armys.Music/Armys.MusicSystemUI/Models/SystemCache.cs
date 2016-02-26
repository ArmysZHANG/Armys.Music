using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Armys.MusicTool;
using Armys.MusicEntity;

namespace Armys.MusicSystemUI.Models
{
    public class SystemCache
    {
        /// <summary>
        /// 设置用户登录个人信息  Cookie
        /// </summary>
        /// <param name="users"></param>
        public void SetLoginInfo(SysUserInfoEntity users)
        {
            const string cookieName = "userInfo";
            var cookie = new Cache().GetCookie(cookieName);
            users.Name = new Codecs().Encode(users.Name, "UTF-8");
            users.GroupName = new Codecs().Encode(users.GroupName, "UTF-8");
            if (cookie == null)
            {
                cookie = new HttpCookie(cookieName);
                cookie.Values.Add("Id", users.Id.ToString());
                cookie.Values.Add("Name", users.Name);
                cookie.Values.Add("HeadPortrait", users.HeadPortrait);
                cookie.Values.Add("GroupId", users.GroupId.ToString());
                cookie.Values.Add("GroupName", users.GroupName);
                cookie.Values.Add("RememberPassword", users.RememberPassword);
                //设置过期时间
                cookie.Expires = DateTime.Now.AddDays(7);
                new Cache().AddCookie(cookie);
            }
            else if (!cookie.Values["Id"].Equals(users.Id.ToString()) || !cookie.Values["Name"].Equals(users.Name) || !cookie.Values["HeadPortrait"].Equals(users.HeadPortrait) || !cookie.Values["RememberPassword"].Equals(users.RememberPassword) || !cookie.Values["GroupId"].Equals(users.GroupId.ToString()) || !cookie.Values["GroupName"].Equals(users.GroupName))
            {
                new Cache().SetCookie(cookieName, "Id", users.Id.ToString(), 7, "days");
                new Cache().SetCookie(cookieName, "Name", users.Name, 7, "days");
                new Cache().SetCookie(cookieName, "HeadPortrait", users.HeadPortrait, 7, "days");
                new Cache().SetCookie(cookieName, "GroupId", users.GroupId.ToString(), 7, "days");
                new Cache().SetCookie(cookieName, "GroupName", users.GroupName, 7, "days");
                new Cache().SetCookie(cookieName, "RememberPassword", users.RememberPassword, 7, "days");
            }
        }

        public void SetLoginPwd(string password, double hours, string unit)
        {
            string cookieName = "passwordSet";
            HttpCookie cookie = new Cache().GetCookie(cookieName);
            if (cookie == null)
            {
                cookie = new HttpCookie(cookieName);
                cookie.Values.Add("password", password);
                //设置过期时间
                cookie.Expires = "days" == unit ? DateTime.Now.AddDays(hours) : DateTime.Now.AddHours(hours);
                new Cache().AddCookie(cookie);
            }
            else if (!cookie.Values["password"].Equals(password))
            {
                new Cache().SetCookie(cookieName, "password", password, hours, unit);
            }
        }
    }
}