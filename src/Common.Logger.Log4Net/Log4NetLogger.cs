/**********************************************************************************************************************
 * 描述：
 *      log4net 日志记录者。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月18日	 新建
 * 
 *********************************************************************************************************************/

using ILog = Wlitsoft.Framework.Common.Core.ILog;

namespace Wlitsoft.Framework.Common.Logger.Log4Net
{
    /// <summary>
    /// log4net 日志记录者。
    /// </summary>
    public class Log4NetLogger : ILog
    {
        //log4net日志。
        private readonly log4net.ILog _log;

        #region 构造方法

        /// <summary>
        /// 初始化<see cref="Log4NetLogger"/> 类的新实例。
        /// <param name="log">log4net 日志记录者。</param>
        /// </summary>
        public Log4NetLogger(log4net.ILog log)
        {
            this._log = log;
        }

        #endregion

        #region ILog 成员

        /// <summary>
        /// 记录一般信息。
        /// </summary>
        /// <param name="message">日志信息。</param>
        public void Info(object message)
        {
            this._log.Info(message);
        }

        /// <summary>
        /// 记录调试级别日志信息。
        /// </summary>
        /// <param name="message">日志信息。</param>
        public void Debug(object message)
        {
            this._log.Debug(message);
        }

        /// <summary>
        /// 记录调试级别日志信息包括异常堆栈信息。
        /// </summary>
        /// <param name="message">日志信息。</param>
        /// <param name="ex">异常对象。</param>
        public void Debug(object message, System.Exception ex)
        {
            this._log.Debug(message, ex);
        }

        /// <summary>
        /// 记录系统错误级别日志信息。
        /// </summary>
        /// <param name="message">日志信息。</param>
        public void Error(object message)
        {
            this._log.Error(message);
        }

        /// <summary>
        /// 记录系统错误级别日志信息包括异常堆栈信息。
        /// </summary>
        /// <param name="message">日志信息。</param>
        /// <param name="ex">异常对象。</param>
        public void Error(object message, System.Exception ex)
        {
            this._log.Error(message, ex);
        }

        /// <summary>
        /// 记录致命级别日志信息。
        /// </summary>
        /// <param name="message">日志信息。</param>
        public void Fatal(object message)
        {
            _log.Fatal(message);
        }

        /// <summary>
        /// 记录致命级别日志信息包括异常堆栈信息。
        /// </summary>
        /// <param name="message">日志信息。</param>
        /// <param name="ex">异常对象。</param>
        public void Fatal(object message, System.Exception ex)
        {
            _log.Fatal(message, ex);
        }

        #endregion
    }
}
