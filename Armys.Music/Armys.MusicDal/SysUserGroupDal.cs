using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armys.MusicDal
{
    /// <summary>
    /// 权限组
    /// </summary>
    public class SysUserGroupDal
    {
        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="authorityModel">状态</param>
        /// <returns>返回状态</returns>
        public int UpdateTags(sys_authority authorityModel)
        {
            using (var authority =new MusicDatabaseEntities())
            {
                var list =
                    authority.sys_authority.FirstOrDefault(
                        at => at.function_id == authorityModel.function_id && at.usergroup_id == authorityModel.usergroup_id);
                if (list != null)
                {
                    list.display = authorityModel.display;
                    list.delete = authorityModel.delete;
                    list.edit = authorityModel.edit;
                    list.insert = authorityModel.insert;
                }
                else
                {
                    authority.sys_authority.Add(authorityModel);
                }
                return authority.SaveChanges();
            }
        }
    }
}
