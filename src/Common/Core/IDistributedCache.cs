/**********************************************************************************************************************
 * 描述：
 *      分布式缓存接口。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月31日	 新建
 * 
 *********************************************************************************************************************/

using System;

namespace Wlitsoft.Framework.Common.Core
{
    /// <summary>
    /// 分布式缓存接口。
    /// </summary>
    public interface IDistributedCache
    {
        /// <summary>
        /// 获取缓存。
        /// </summary>
        /// <typeparam name="T">缓存类型。</typeparam>
        /// <param name="key">缓存键值。</param>
        /// <returns>获取到的缓存。</returns>
        T Get<T>(string key);

        /// <summary>
        /// 设置缓存。
        /// </summary>
        /// <typeparam name="T">缓存类型。</typeparam>
        /// <param name="key">缓存键值。</param>
        /// <param name="value">要缓存的对象。</param>
        void Set<T>(string key, T value);

        /// <summary>
        /// 设置缓存。
        /// </summary>
        /// <typeparam name="T">缓存类型。</typeparam>
        /// <param name="key">缓存键值。</param>
        /// <param name="value">要缓存的对象。</param>
        /// <param name="expiredTime">过期时间。</param>
        void Set<T>(string key, T value, TimeSpan expiredTime);

        /// <summary>
        /// 判断指定键值的缓存是否存在。
        /// </summary>
        /// <param name="key">缓存键值。</param>
        /// <returns>一个布尔值，表示缓存是否存在。</returns>
        bool Exists(string key);

        /// <summary>
        /// 移除指定键值的缓存。
        /// </summary>
        /// <param name="key">缓存键值。</param>
        bool Remove(string key);

        /// <summary>
        /// 获取 Hash 表中的缓存。
        /// </summary>
        /// <typeparam name="T">缓存类型。</typeparam>
        /// <param name="key">缓存键值。</param>
        /// <param name="hashField">要获取的 hash 字段。</param>
        /// <returns>获取到的缓存。</returns>
        T GetHash<T>(string key, string hashField);

        /// <summary>
        /// 设置 缓存到 Hash 表。
        /// </summary>
        /// <typeparam name="T">缓存类型。</typeparam>
        /// <param name="key">缓存键值。</param>
        /// <param name="hashField">要设置的 hash 字段。</param>
        /// <param name="hashValue">要设置的 hash 值。</param>
        void SetHash<T>(string key, string hashField, T hashValue);

        /// <summary>
        /// 判断指定键值的 Hash 缓存是否存在。
        /// </summary>
        /// <param name="key">缓存键值。</param>
        /// <param name="hashField">hash 字段。</param>
        /// <returns>一个布尔值，表示缓存是否存在。</returns>
        bool ExistsHash(string key, string hashField);

        /// <summary>
        /// 删除 hash 表中的指定字段的缓存。
        /// </summary>
        /// <param name="key">缓存键值。</param>
        /// <param name="hashField">hash 字段。</param>
        /// <returns>一个布尔值，表示缓存是否删除成功。</returns>
        bool DeleteHash(string key, string hashField);
    }
}
