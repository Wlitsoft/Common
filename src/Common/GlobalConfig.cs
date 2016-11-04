/**********************************************************************************************************************
 * 描述：
 *      全局配置静态类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年11月04日	 新建
 *********************************************************************************************************************/
using Wlitsoft.Framework.Common.Serialize;

namespace Wlitsoft.Framework.Common
{
    /// <summary>
    /// 全局配置静态类。
    /// </summary>
    public static class GlobalConfig
    {
        #region 公共属性

        /// <summary>
        /// 序列化者工厂。
        /// </summary>
        public static SerializerFactory SerializerFactory;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化 <see cref="GlobalConfig"/> 的静态实例。
        /// </summary>
        static GlobalConfig()
        {
            SerializerFactory = new SerializerFactory();
        }

        #endregion
    }
}
