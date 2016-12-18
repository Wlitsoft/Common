/**********************************************************************************************************************
 * 描述：
 *      日志服务。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月17日	 新建
 * 
 *********************************************************************************************************************/

using System.Collections.Generic;
using System.Linq;
using Wlitsoft.Framework.Common.Core;
using Wlitsoft.Framework.Common.Exception;

namespace Wlitsoft.Framework.Common.Log
{
    /// <summary>
    /// 日志服务。
    /// </summary>
    public class LoggerService
    {
        //日志记录者。
        internal static Dictionary<string, ILog> Loggers;

        //默认的日志记录者名称。
        internal static string DefaultLoggerName;

        #region 构造方法

        static LoggerService()
        {
            Loggers = new Dictionary<string, ILog>();
            DefaultLoggerName = "default";
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 获取默认的 <see cref="ILog"/> 实例。
        /// </summary>
        /// <returns>一个 <see cref="ILog"/> 类型的对象实例。</returns>
        public ILog GetLogger()
        {
            return this.GetLogger(DefaultLoggerName);
        }

        /// <summary>
        /// 获取一个 <see cref="ILog"/> 的实例。
        /// <param name="name">日志记录者名称。</param>
        /// </summary>
        /// <returns>一个 <see cref="ILog"/> 类型的对象实例。</returns>
        public ILog GetLogger(string name)
        {
            #region 参数校验

            if (string.IsNullOrEmpty(name))
                throw new StringNullOrEmptyException(nameof(name));

            #endregion

            //如果为空，则初始化一个空的日志记录者。
            if (!Loggers.Any())
                return new EmptyLogger();

            return Loggers[name];
        }

        /// <summary>
        /// 设置日志记录者。
        /// </summary>
        /// <param name="name">日志记录者名称。</param>
        /// <param name="logger">日志记录者。</param>
        internal void SetLogger(string name, ILog logger)
        {
            #region 参数校验

            if (string.IsNullOrEmpty(name))
                throw new StringNullOrEmptyException(nameof(name));

            if (logger == null)
                throw new ObjectNullException(nameof(logger));

            #endregion

            //如果存在则移除，
            if (Loggers.ContainsKey(name))
                Loggers.Remove(name);

            Loggers.Add(name, logger);
        }

        #endregion

    }
}
