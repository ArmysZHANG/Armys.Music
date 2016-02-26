using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Armys.MusicEntity;
using Armys.MusicTool;

namespace Armys.MusicDal
{
    public class SysUserDal
    {
        /// <summary>
        /// 根据用户名、密码查询正常状态的用户
        /// </summary>
        /// <param name="users">用户对象</param>
        /// <returns></returns>
        public SysUserInfoEntity GetUserInfo(sys_userinfo users)
        {
            using (var user = new MusicDatabaseEntities())
            {
                var result = (from userinfo in user.sys_vw_userinfo
                              where userinfo.name == users.name
                              && userinfo.password == users.password
                              && userinfo.status
                              select new SysUserInfoEntity()
                              {
                                  Id = userinfo.id,
                                  GroupId = userinfo.groupid,
                                  GroupName = userinfo.groupname,
                                  Name = userinfo.name,
                                  HeadPortrait = userinfo.headportrait
                              }).FirstOrDefault();
                return result;
            }
        }

        /// <summary>
        /// 根据用户编号，获取用户组
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns>用户组名称</returns>
        public string GetUserGroup(int userId)
        {
            using (var userGroup = new MusicDatabaseEntities())
            {
                userGroup.Configuration.ProxyCreationEnabled = false;
                var result = (from usergroup in userGroup.sys_usergroup
                              join arragement in userGroup.sys_arragement
                                  on usergroup.id equals arragement.usergroup_id
                              where arragement.userinfo_id == userId
                              select usergroup).FirstOrDefault();
                if (result != null)
                    return result.name;
                return "";
            }
        }

        /// <summary>
        /// 根据用户编号获取用户权限
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<sys_function> GetUserFunction(int userId)
        {
            using (var function = new MusicDatabaseEntities())
            {
                function.Configuration.ProxyCreationEnabled = false;
                var result = (from usergroup in function.sys_usergroup
                              join arragement in function.sys_arragement
                                  on usergroup.id equals arragement.usergroup_id
                              join acthority in function.sys_authority
                                  on usergroup.id equals acthority.usergroup_id
                              join ftion in function.sys_function
                                  on acthority.function_id equals ftion.id
                              where arragement.userinfo_id == userId
                                    && acthority.display
                                    && ftion.function_id == 0
                                    && usergroup.status
                              orderby ftion.sequence
                              select ftion).ToList();
                return result;
            }
        }

        /// <summary>
        /// 根据菜单编号获取子菜单
        /// </summary>
        /// <param name="menuId">菜单编号</param>
        /// <param name="groupId">用户组</param>
        /// <returns></returns>
        public List<sys_function> GetChildMenu(int menuId, int groupId)
        {
            using (var childMenu = new MusicDatabaseEntities())
            {
                childMenu.Configuration.ProxyCreationEnabled = false;
                var result = (from function in childMenu.sys_function
                              join authority in childMenu.sys_authority
                                  on function.id equals authority.function_id
                              where function.function_id == menuId
                                    && authority.display
                                    && authority.usergroup_id == groupId
                              orderby function.sequence
                              select function).ToList();
                return result;
            }
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <param name="searchValue">搜索值</param>
        /// <param name="pageIndex">显示页</param>
        /// <param name="pageSize">显示行数</param>
        /// <param name="sortKey">排序值</param>
        /// <param name="sortType">排序类型</param>
        /// <returns></returns>
        public ResultObjClass GetAllUser(string searchValue, int pageIndex = 1, int pageSize = 10,
            string sortKey = "Id", string sortType = "ASC")
        {
            using (var sysUser = new MusicDatabaseEntities())
            {
                string condition = " order by " + sortKey + " " + sortType;
                if (!string.IsNullOrEmpty(searchValue))
                    condition = " where userInfo.name like '" + searchValue + "%' or userInfo.mobilephone like '" + searchValue + "%' or userInfo.email like '" + searchValue + "%'" + " order by " + sortKey + " " + sortType;
                string sql =
                    @"select userInfo.id,userInfo.name, userInfo.email,userInfo.personalinformation,userInfo.remark,userInfo.headportrait, userInfo.status,userInfo.mobilephone,
                    CASE WHEN userGroup.name = '' THEN '未分配角色' when userGroup.name is null THEN '未分配角色' else userGroup.name end as GroupName,
                    case when userGroup.status is null then '0' else userGroup.status end as GroupStatus 
                    from sys_userinfo as userInfo
                    left join sys_arragement as arragement
                    on userInfo.id = arragement.userinfo_id
                    left join sys_usergroup as userGroup
                    on userGroup.id = arragement.usergroup_id" + condition + ";";
                var listUser = sysUser.Database.SqlQuery<SysUserQueryEntity>(sql);
                var count = listUser.Count();
                return new ResultObjClass()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    PageTotalCount = count,
                    PageObject = listUser.ToList()
                };
            }
        }

        /// <summary>
        /// 查询所有用户组
        /// </summary>
        /// <param name="searchValue">搜索值</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">显示行</param>
        /// <param name="sortKey">排序编号</param>
        /// <param name="sortType">排序类型</param>
        /// <returns></returns>
        public ResultObjClass GetAllUserGroup(string searchValue, int pageIndex = 1, int pageSize = 10,
            string sortKey = "id", string sortType = "ASC")
        {
            using (var userGroup = new MusicDatabaseEntities())
            {
                var list = userGroup.sys_usergroup.AsQueryable();
                if (!string.IsNullOrEmpty(searchValue))
                    list = list.Where(ug => ug.name.IndexOf(searchValue) > -1);
                list = list.EfOrderBy(sortKey, sortType);
                var count = list.Count();
                list = list.EfSort(pageIndex, pageSize);
                return new ResultObjClass()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    PageTotalCount = count,
                    PageObject = list.ToList()
                };
            }
        }

        /// <summary>
        /// 更新用户组状态
        /// </summary>
        /// <param name="groupId">组编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int UpdateStatus(int groupId, bool status)
        {
            using (var userGroup = new MusicDatabaseEntities())
            {
                var model = userGroup.sys_usergroup.FirstOrDefault(ug => ug.id == groupId);
                if (model != null) model.status = status;
                return userGroup.SaveChanges();
            }
        }

        /// <summary>
        /// 根据登录用户获取所有顶级菜单
        /// </summary>
        /// <returns></returns>
        public List<SysFunctionEntity> GetAllActiveFunction(int groupId)
        {
            using (var function = new MusicDatabaseEntities())
            {
                string sql = @"select sf.id, sf.name, sf.ico,
                                CASE WHEN sa.display = '' THEN 'false' when sa.display is null THEN 'false' else sa.display end as Display,
                                CASE WHEN sa.edit = '' THEN 'false' when sa.edit is null THEN 'false' else sa.edit end as Edit,
                                CASE WHEN sa.[delete] = '' THEN 'false' when sa.[delete] is null THEN 'false' else sa.[delete] end as [Delete],
                                CASE WHEN sa.[insert] = '' THEN 'false' when sa.[insert] is null THEN 'false' else sa.[insert] end as [Insert]
                                from sys_function sf
                                left join sys_authority sa
                                on sa.function_id = sf.id
                                and sf.function_id = 0
                                where sa.usergroup_id = " + groupId;
                var listFtion = function.Database.SqlQuery<SysFunctionEntity>(sql);
                return listFtion.ToList();
            }
        }

        /// <summary>
        /// 根据菜单编号获取子菜单
        /// </summary>
        /// <param name="menuId">菜单编号</param>
        /// <returns></returns>
        public List<sys_function> GetAllChildMenu(int menuId)
        {
            using (var childMenu = new MusicDatabaseEntities())
            {
                childMenu.Configuration.ProxyCreationEnabled = false;
                var result =
                    childMenu.sys_function.Where(cm => cm.function_id == menuId).OrderBy(m => m.sequence).ToList();
                return result;
            }
        }
    }
}
