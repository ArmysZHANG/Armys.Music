using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armys.MusicEntity
{
    /// <summary>
    /// 用户当前组
    /// </summary>
    public class SysFunctionEntity
    {
        public int Id { get; set; } //模块编号
        public string Name { get; set; }  //模块名称
        public string Ico { get; set; }  //模块显示标签
        public bool Display { get; set; }  //显示
        public bool Edit { get; set; }  //修改
        public bool Delete { get; set; } //删除
        public bool Insert { get; set; } //新增
    }
}
