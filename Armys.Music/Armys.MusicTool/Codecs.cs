using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;

namespace Armys.MusicTool
{
    /// <summary>
    /// 内容编码解码
    /// </summary>
    public class Codecs
    {
        /// <summary>
        /// UTF 8 编码
        /// </summary>
        /// <param name="values">值</param>
        /// <param name="format">编码格式</param>
        /// <returns></returns>
        public string Encode(string values, string format)
        {
            return HttpUtility.UrlEncode(values, System.Text.Encoding.GetEncoding(format));
        }

        /// <summary>
        /// UTF 8 解码
        /// </summary>
        /// <param name="values">值</param>
        /// <param name="format">编码格式</param>
        /// <returns></returns>
        public string Decode(string values, string format)
        {
            return HttpUtility.UrlDecode(values, System.Text.Encoding.GetEncoding(format));
        }
    }
}
