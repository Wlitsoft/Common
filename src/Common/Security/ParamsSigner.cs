/**********************************************************************************************************************
 * 描述：
 *      参数签名者。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年11月09日	 新建
 *********************************************************************************************************************/

using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wlitsoft.Framework.Common.Extension;

namespace Wlitsoft.Framework.Common.Security
{
    /// <summary>
    /// 参数签名者。
    /// </summary>
    public class ParamsSigner
    {
        #region 公共属性

        /// <summary>
        /// 获取或设置约定的秘钥。
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// 获取或设置要前面的参数集合。
        /// </summary>
        public IDictionary<string, string> Params { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化 <see cref="ParamsSigner"/> 类的新实例。
        /// </summary>
        /// <param name="secretKey">约定的秘钥。</param>
        public ParamsSigner(string secretKey)
        {
            this.SecretKey = secretKey;
            this.Params = new Dictionary<string, string>();
        }

        #endregion

        #region 获得签名字符串

        /// <summary>
        /// 获得签名字符串。
        /// </summary>
        /// <returns>签名字符串。</returns>
        public string GetSign()
        {
            StringBuilder sb = new StringBuilder();

            //参数名ASCII码从小到大排序。
            var sortedParmas = this.Params.OrderBy(d => d.Key);
            foreach (var item in sortedParmas)
            {
                //如果参数值为空则跳过。
                if (string.IsNullOrEmpty(item.Value))
                    continue;

                sb.AppendFormat($"{item.Key}={item.Value}&");
            }
            sb.AppendFormat($"key={this.SecretKey}");
            return sb.ToString().GetMD5(Encoding.UTF8);
        }

        #endregion
    }
}
