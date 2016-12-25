/**********************************************************************************************************************
 * 描述：
 *      DateTime 类型扩展方法静态类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 *********************************************************************************************************************/

using System;

namespace Wlitsoft.Framework.Common.Extension
{
    /// <summary>
    /// DateTime 类型扩展方法静态类。
    /// </summary>
    public static class DateTimeExtension
    {
        #region 公共属性

        /// <summary>
        /// Unix 开始时间。
        /// </summary>
        public static DateTime UnixStartDateTime = new DateTime(1970, 1, 1);

        #endregion

        #region 将给定 DateTime 时间转换为 Unix 时间戳。

        /// <summary>
        /// 将给定 DateTime 时间转换为 Unix 时间戳。
        /// </summary>
        /// <param name="dateTime">DateTime 时间。</param>
        /// <returns>Unix 时间戳。</returns>
        public static long GetUnixTimestamp(this DateTime dateTime)
        {
            return (dateTime.Ticks - UnixStartDateTime.Ticks) / 10000000 - 8 * 60 * 60;
        }

        #endregion
    }
}
