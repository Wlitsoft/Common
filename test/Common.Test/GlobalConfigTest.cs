/**********************************************************************************************************************
 * 描述：
 *      全局配置静态类 测试。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年11月04日	 新建
 *********************************************************************************************************************/

using Wlitsoft.Framework.Common;
using Xunit;

namespace Common.Test
{
    /// <summary>
    /// 全局配置静态类 测试。
    /// </summary>
    public class GlobalConfigTest
    {
        [Fact]
        public void GetSerializerFactoryTest()
        {
            Assert.NotNull(GlobalConfig.SerializerFactory);
        }
    }
}
