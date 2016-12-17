/**********************************************************************************************************************
 * 描述：
 *      全局配置静态类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年11月04日	 新建
 *      作者：李亮  时间：2016年12月17日	 重新定位该类作用。
 *********************************************************************************************************************/

using Wlitsoft.Framework.Common.Core;
using Wlitsoft.Framework.Common.Exception;

namespace Wlitsoft.Framework.Common
{
    /// <summary>
    /// 全局配置静态类。
    /// </summary>
    public static class GlobalConfig
    {
        /// <summary>
        /// 配置序列化者。
        /// </summary>
        /// <param name="type">序列化类型。</param>
        /// <param name="serializer">序列化者接口。</param>
        public static void ConfigSerializer(SerializeType type, ISerializer serializer)
        {
            #region 参数校验

            if (serializer == null)
                throw new ObjectNullException(nameof(serializer));

            #endregion

            App.SerializerService.SetSerializer(type, serializer);
        }

        /// <summary>
        /// 配置日志记录者。
        /// </summary>
        /// <param name="logger">日志接口。</param>
        public static void ConfigLogger(ILog logger)
        {
            #region 参数校验

            if (logger == null)
                throw new ObjectNullException(nameof(logger));

            #endregion

            App.LoggerService.SetLogger(logger);
        }
    }
}
