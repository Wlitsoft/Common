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
using Wlitsoft.Framework.Common.Exception;

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

        /// <summary>
        /// 根据枚举项上的描述信息获取指定的枚举项。
        /// </summary>
        /// <typeparam name="TEnum">枚举类型。</typeparam>
        /// <param name="des">枚举项描述信息。</param>
        /// <returns>获取到的枚举项。</returns>
        public static TEnum GetEnumItemByDescription<TEnum>(string des)
        {

            #region 参数校验

            if (string.IsNullOrEmpty(des))
                throw new StringNullOrEmptyException(nameof(des));

            #endregion

            Type enumType = typeof(TEnum);
            FieldInfo[] finfos = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            FieldInfo info = finfos.FirstOrDefault(p => p.GetCustomAttribute<DescriptionAttribute>(false).Description == des);
            if (info == null)
                throw new System.Exception($"在枚举（{enumType.FullName}）中，未发现描述为“{des}”的枚举项。");

            return (TEnum)Enum.Parse(enumType, info.Name);
        }
    }
}
