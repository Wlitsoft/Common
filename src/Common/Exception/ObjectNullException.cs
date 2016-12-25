/**********************************************************************************************************************
 * 描述：
 *      当对象为空引用的时候引发的异常。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年11月01日	 新建
 * 
 *********************************************************************************************************************/
using System;

namespace Wlitsoft.Framework.Common.Exception
{
    /// <summary>
    /// 当对象为空引用的时候引发的异常。
    /// </summary>
    public class ObjectNullException : ArgumentNullException
    {
        #region 构造方法

        /// <summary>
        /// 使用参数名称初始化 <see cref="ObjectNullException"/> 类的新实例。 
        /// </summary>
        /// <param name="paraName"></param>
        public ObjectNullException(string paraName)
            : base(paraName)
        {

        }

        #endregion

        #region ArgumentException 成员

        /// <summary>
		/// 获取描述当前异常的消息。
		/// </summary>
        public override string Message => string.Format(Properties.Resource.ObjectNullExceptionMsg, base.ParamName);

        #endregion
    }
}
