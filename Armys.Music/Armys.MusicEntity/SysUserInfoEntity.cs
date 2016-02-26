using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armys.MusicEntity
{
    /// <summary>
    /// 用户实体
    /// </summary>
    public class SysUserInfoEntity
    {
        public int Id { get; set; } //用户编号
        public string Name { get; set; }  //用户名称
        public string HeadPortrait { get; set; }  //用户头像
        public int GroupId { get; set; }  //用户组
        public string GroupName { get; set; }  //用户组名称
        public string RememberPassword { get; set; } //是否保存密码
    }
}
