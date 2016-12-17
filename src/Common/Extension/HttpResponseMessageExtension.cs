/**********************************************************************************************************************
 * 描述：
 *      包含状态码和数据的 HTTP 相应消息扩展静态类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年11月06日	新建
 * 
 *********************************************************************************************************************/

using System.IO;
using System.Net.Http;

namespace Wlitsoft.Framework.Common.Extension
{
    /// <summary>
    /// 包含状态码和数据的 HTTP 相应消息扩展静态类。
    /// </summary>
    public static class HttpResponseMessageExtension
    {
        /// <summary>
        /// 获取 <see cref="string"/> 字符串结果。
        /// </summary>
        /// <param name="httpResponseMessage">包含状态码和数据的 HTTP 相应消息。</param>
        /// <returns>一个 <see cref="string"/> 字符串。</returns>
        public static string GetResultString(this HttpResponseMessage httpResponseMessage)
        {
            return httpResponseMessage.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// 获取 <see cref="Stream"/> 流结果。
        /// </summary>
        /// <param name="httpResponseMessage">包含状态码和数据的 HTTP 相应消息。</param>
        /// <returns>一个 <see cref="Stream"/> 流。</returns>
        public static Stream GetResultStream(this HttpResponseMessage httpResponseMessage)
        {
            return httpResponseMessage.Content.ReadAsStreamAsync().Result;
        }

        /// <summary>
        /// 获取 <see cref="byte"/> 数组结果。
        /// </summary>
        /// <param name="httpResponseMessage">包含状态码和数据的 HTTP 相应消息。</param>
        /// <returns>一个 <see cref="byte"/> 数组。</returns>
        public static byte[] GetResultBytes(this HttpResponseMessage httpResponseMessage)
        {
            return httpResponseMessage.Content.ReadAsByteArrayAsync().Result;
        }
    }
}
