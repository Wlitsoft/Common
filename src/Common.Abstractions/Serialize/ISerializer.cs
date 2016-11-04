/**********************************************************************************************************************
 * 描述：
 *      序列化者接口。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年11月03日	 新建
 * 
 *********************************************************************************************************************/

using System;

namespace Wlitsoft.Framework.Common.Abstractions.Serialize
{
    /// <summary>
    /// 序列化者接口。
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// 获取序列化类型。
        /// </summary>
        SerializeType SerializeType { get; }

        /// <summary>
        /// 将一个对象序列化成一个字符串。
        /// </summary>
        /// <param name="obj">要序列化的对象。</param>
        /// <returns>序列化后的字符串。</returns>
        string Serialize(object obj);

        /// <summary>
        /// 将一个字符串反序列化为一个对象。
        /// </summary>
        /// <param name="objType">要反序序列化的对象类型。</param>
        /// <param name="str">要反序列化的字符串。</param>
        /// <returns>反序列化得到的对象。</returns>
        object Deserialize(Type objType, string str);

        /// <summary>
        /// 将一个字符串反序列化为一个对象。
        /// </summary>
        /// <param name="str">要反序列化的字符串。</param>
        /// <returns>反序列化得到的对象。</returns>
        T Deserialize<T>(string str);
    }
}
