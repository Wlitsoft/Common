/**********************************************************************************************************************
 * 描述：
 *      应用 构造 静态扩展类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月18日	 新建
 * 
 *********************************************************************************************************************/

using System.Collections.Generic;
using System.IO;
using System.Linq;
using log4net;
using log4net.Config;
using Wlitsoft.Framework.Common.Exception;

namespace Wlitsoft.Framework.Common.Logger.Log4Net
{
    /// <summary>
    /// 应用 构造 静态扩展类。
    /// </summary>
    public static class AppBuilderExtension
    {
        /// <summary>
        /// 以 xml 配置文件的方式设置 log4net 日志记录者。
        /// </summary>
        /// <param name="appBuilder">应用构造。</param>
        /// <param name="configFilePath">配置文件路径。</param>
        public static void SetLog4NetLoggerByXmlConfig(this AppBuilder appBuilder, string configFilePath)
        {
            #region 参数校验

            if (string.IsNullOrEmpty(configFilePath))
                throw new StringNullOrEmptyException(nameof(configFilePath));

            #endregion

            XmlConfigurator.Configure(new FileInfo(configFilePath));
            List<ILog> logs = LogManager.GetCurrentLoggers().ToList();
            foreach (ILog log in logs)
            {
                appBuilder.AddLogger(log.Logger.Name, new Log4NetLogger(log));
            }
        }
    }
}
