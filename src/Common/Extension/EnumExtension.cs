/**********************************************************************************************************************
 * 描述：
 *      枚举类型扩展方法静态类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 *********************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Wlitsoft.Framework.Common.Extension
{
    /// <summary>
    /// 枚举类型扩展方法静态类。
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// 获取枚举项上的 <see cref="DescriptionAttribute"/> 标记信息。
        /// </summary>
        /// <param name="enumItem">枚举项。</param>
        /// <returns>标记信息。</returns>
        public static string GetDescription(this Enum enumItem)
        {
            Type enumType = enumItem.GetType();
            FieldInfo fi = enumType.GetField(enumItem.ToString());
            IEnumerable<DescriptionAttribute> desAttrs = fi.GetCustomAttributes<DescriptionAttribute>(false);

            //如果未找到则，
            if (!desAttrs.Any())
                throw new System.Exception(string.Format(Properties.Resource.EnumItemNotFoundDescription, enumItem));

            return desAttrs.First().Description;
        }
    }
}
