/**********************************************************************************************************************
 * 描述：
 *      应用。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月17日	 新建
 * 
 *********************************************************************************************************************/

using Wlitsoft.Framework.Common.Log;
using Wlitsoft.Framework.Common.Serialize;

namespace Wlitsoft.Framework.Common
{
    /// <summary>
    /// 应用。
    /// </summary>
    public class App
    {
        /// <summary>
        /// 获取序列化服务。
        /// </summary>
        public static SerializerService SerializerService { get; private set; }

        /// <summary>
        /// 获取日志服务。
        /// </summary>
        public static LoggerService LoggerService { get; private set; }

        /// <summary>
        /// 获取应用构造者。
        /// </summary>
        public static AppBuilder Builder { get; private set; }

        /// <summary>
        /// 初始化 <see cref="App"/> 的静态实例。
        /// </summary>
        static App()
        {
            SerializerService = new SerializerService();
            LoggerService = new LoggerService();
            Builder = new AppBuilder();
        }
    }
}
