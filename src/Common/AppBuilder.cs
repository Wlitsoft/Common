/**********************************************************************************************************************
 * 描述：
 *      应用 构造。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月18日	 新建
 * 
 *********************************************************************************************************************/

using Wlitsoft.Framework.Common.Core;
using Wlitsoft.Framework.Common.Exception;

namespace Wlitsoft.Framework.Common
{
    /// <summary>
    /// 应用 构造。
    /// </summary>
    public class AppBuilder
    {
        #region 添加序列化者

        /// <summary>
        /// 添加序列化者。
        /// </summary>
        /// <param name="type">序列化类型。</param>
        /// <param name="serializer">序列化者接口。</param>
        public void AddSerializer(SerializeType type, ISerializer serializer)
        {
            #region 参数校验

            if (serializer == null)
                throw new ObjectNullException(nameof(serializer));

            #endregion

            App.SerializerService.SetSerializer(type, serializer);
        }

        #endregion

        #region 添加日志记录者

        /// <summary>
        /// 添加日志记录者。
        /// </summary>
        /// <param name="name">日志记录者名称。</param>
        /// <param name="logger">日志接口。</param>
        public void AddLogger(string name, ILog logger)
        {
            #region 参数校验

            if (string.IsNullOrEmpty(name))
                throw new StringNullOrEmptyException(nameof(name));

            if (logger == null)
                throw new ObjectNullException(nameof(logger));

            #endregion

            App.LoggerService.SetLogger(name, logger);
        }

        #endregion
    }
}
