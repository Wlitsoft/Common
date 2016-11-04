/**********************************************************************************************************************
 * 描述：
 *      当字符串为空或空引用的时候引发的异常。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年11月01日	 新建
 * 
 *********************************************************************************************************************/
using System;

namespace Wlitsoft.Framework.Common.Exception
{
    /// <summary>
	/// 当字符串为空或空引用的时候引发的异常。
	/// </summary>
    public class StringNullOrEmptyException : ArgumentException
    {
        #region 构造方法

        /// <summary>
        /// 使用参数名称初始化 <see cref="StringNullOrEmptyException"/> 类的新实例。 
        /// </summary>
        /// <param name="paraName"></param>
        public StringNullOrEmptyException(string paraName)
            :base(paraName)
        {

        }

        #endregion

        #region ArgumentException 成员

        /// <summary>
		/// 获取描述当前异常的消息。
		/// </summary>
        public override string Message => string.Format(Properties.Resource.StringNullOrEmptyExceptionMsg, base.ParamName);

        #endregion
    }
}
