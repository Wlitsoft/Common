/**********************************************************************************************************************
 * 描述：
 *      空的日志记录者。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月17日	 新建
 * 
 *********************************************************************************************************************/

using Wlitsoft.Framework.Common.Core;

namespace Wlitsoft.Framework.Common.Log
{
    /// <summary>
    /// 空的日志记录者。
    /// </summary>
    public class EmptyLogger : ILog
    {
        #region ILog 成员

        /// <summary>
        /// 记录一般信息。
        /// </summary>
        /// <param name="message">日志信息。</param>
        public void Info(object message)
        {

        }

        /// <summary>
        /// 记录调试级别日志信息。
        /// </summary>
        /// <param name="message">日志信息。</param>
        public void Debug(object message)
        {

        }

        /// <summary>
        /// 记录调试级别日志信息包括异常堆栈信息。
        /// </summary>
        /// <param name="message">日志信息。</param>
        /// <param name="ex">异常对象。</param>
        public void Debug(object message, System.Exception ex)
        {

        }

        /// <summary>
        /// 记录系统错误级别日志信息。
        /// </summary>
        /// <param name="message">日志信息。</param>
        public void Error(object message)
        {

        }

        /// <summary>
        /// 记录系统错误级别日志信息包括异常堆栈信息。
        /// </summary>
        /// <param name="message">日志信息。</param>
        /// <param name="ex">异常对象。</param>
        public void Error(object message, System.Exception ex)
        {

        }

        #endregion
    }
}
