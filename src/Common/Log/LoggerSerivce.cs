/**********************************************************************************************************************
 * 描述：
 *      日志服务。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月17日	 新建
 * 
 *********************************************************************************************************************/

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
        private static ILog _logger;

        #region 构造方法

        /// <summary>
        /// 初始化 <see cref="LoggerService"/> 类的静态实例。
        /// </summary>
        static LoggerService()
        {
            _logger = new EmptyLogger();
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 获取一个 <see cref="ILog"/> 的实例。
        /// </summary>
        /// <returns>一个 <see cref="ILog"/> 类型的对象实例。</returns>
        public ILog GetLogger()
        {
            return _logger;
        }

        /// <summary>
        /// 设置日志记录者。
        /// </summary>
        /// <param name="logger">日志记录者。</param>
        internal void SetLogger(ILog logger)
        {
            #region 参数校验

            if (logger == null)
                throw new ObjectNullException(nameof(logger));

            #endregion

            _logger = logger;
        }

        #endregion

    }
}
