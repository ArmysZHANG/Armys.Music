using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Armys.MusicSystemUI.Models
{
    public class ReadSystemConfig
    {
        /// <summary>
        /// 读取系统
        /// </summary>
        /// <param name="keyName">配置名称</param>
        /// <returns></returns>
        public string GetSystemConfig(string keyName)
        {
            return ConfigurationManager.AppSettings[keyName];
        }
    }
}