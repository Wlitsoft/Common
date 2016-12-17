/**********************************************************************************************************************
 * 描述：
 *      对象扩展方法静态类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年11月04日	新建
 * 
 *********************************************************************************************************************/

using Wlitsoft.Framework.Common.Core;
using Wlitsoft.Framework.Common.Exception;

namespace Wlitsoft.Framework.Common.Extension
{
    /// <summary>
    /// 对象扩展方法静态类。
    /// </summary>
    public static class ObjectExtension
    {
      
        #region 将给定对象 (<paramref name="obj"/>) 转换成 JSON 字符串的表示形式

        /// <summary>
        /// 将给定对象(<paramref name="obj"/>)转换成 JSON 字符串的表示形式。
        /// </summary>
        /// <param name="obj">准备进行转换的对象。</param>
        /// <returns>转换后生成的 JSON 字符串。</returns>
        public static string ToJsonString(this object obj)
        {
            #region 参数校验

            if (obj == null)
                throw new ObjectNullException(nameof(obj));

            #endregion

            ISerializer serializer = App.SerializerService.GetJsonSerializer();
            return serializer.Serialize(obj);
        }

        #endregion

        #region 将给定对象 (<paramref name="obj"/>) 转换成 XML 字符串的表示形式

        /// <summary>
        /// 将给定对象 (<paramref name="obj"/>) 转换成 XML 字符串的表示形式。
        /// </summary>
        /// <param name="obj">准备进行转换的对象。</param>
        /// <returns>转换后生成的 XML 字符串。</returns>
        public static string ToXmlString(this object obj)
        {
            #region 参数校验

            if (obj == null)
                throw new ObjectNullException(nameof(obj));

            #endregion

            ISerializer serializer = App.SerializerService.GetXmlSerializer();
            return serializer.Serialize(obj);
        }

        #endregion
    }
}
