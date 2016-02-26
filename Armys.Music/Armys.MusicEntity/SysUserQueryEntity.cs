using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armys.MusicEntity
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public class SysUserQueryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string HeadPortrait { get; set; }
        public bool Status { get; set; }
        public string MobilePhone { get; set; }
        public string Personalinformation { get; set; }
        public string Remark { get; set; }
        public string GroupName { get; set; }
        public bool GroupStatus { get; set; }
    }
}
