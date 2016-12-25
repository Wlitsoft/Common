/**********************************************************************************************************************
 * 描述：
 *      long 类型扩展方法静态类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 * 
 *********************************************************************************************************************/

using System;

namespace Wlitsoft.Framework.Common.Extension
{
    /// <summary>
    /// long 类型扩展方法静态类。
    /// </summary>
    public static class LongExtension
    {
        #region 将给定 Unix 时间戳转换为 <see cref="DateTime"/> 时间

        /// <summary>
        /// 将给定 Unix 时间戳转换为 <see cref="DateTime"/> 时间。
        /// </summary>
        /// <param name="unixTimestamp">Unix 时间戳。</param>
        /// <returns><see cref="DateTime"/> 时间。</returns>
        public static DateTime ToDateTime(this long unixTimestamp)
        {
            long value = (unixTimestamp + 8 * 60 * 60) * 10000000;
            return DateTimeExtension.UnixStartDateTime.AddTicks(value);
        }

        #endregion
    }
}
