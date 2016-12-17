/**********************************************************************************************************************
 * 描述：
 *      日志接口。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月17日	 新建
 * 
 *********************************************************************************************************************/

namespace Wlitsoft.Framework.Common.Core
{
    /// <summary>
    /// 日志接口。
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// 记录一般信息。
        /// </summary>
        /// <param name="message">日志信息。</param>
        void Info(object message);

        /// <summary>
        /// 记录调试级别日志信息。
        /// </summary>
        /// <param name="message">日志信息。</param>
        void Debug(object message);

        /// <summary>
        /// 记录调试级别日志信息包括异常堆栈信息。
        /// </summary>
        /// <param name="message">日志信息。</param>
        /// <param name="ex">异常对象。</param>
        void Debug(object message, System.Exception ex);

        /// <summary>
        /// 记录系统错误级别日志信息。
        /// </summary>
        /// <param name="message">日志信息。</param>
        void Error(object message);

        /// <summary>
        /// 记录系统错误级别日志信息包括异常堆栈信息。
        /// </summary>
        /// <param name="message">日志信息。</param>
        /// <param name="ex">异常对象。</param>
        void Error(object message, System.Exception ex);
    }
}
