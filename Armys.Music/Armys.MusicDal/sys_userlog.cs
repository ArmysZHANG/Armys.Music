//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Armys.MusicDal
{
    using System;
    using System.Collections.Generic;
    
    public partial class sys_userlog
    {
        public int id { get; set; }
        public int userinfo_id { get; set; }
        public string ip { get; set; }
        public string computername { get; set; }
        public System.DateTime modifytime { get; set; }
        public string operationmethod { get; set; }
    
        public virtual sys_userinfo sys_userinfo { get; set; }
    }
}