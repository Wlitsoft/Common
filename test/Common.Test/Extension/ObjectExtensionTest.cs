/**********************************************************************************************************************
 * 描述：
 *      对象扩展方法静态类 测试。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年11月04日	新建
 * 
 *********************************************************************************************************************/

using Common.Test.Model;
using Wlitsoft.Framework.Common.Extension;
using Xunit;

namespace Common.Test.Extension
{
    /// <summary>
    /// 对象扩展方法静态类 测试。
    /// </summary>
    public class ObjectExtensionTest
    {
        private readonly PersonModel _model;

        public ObjectExtensionTest()
        {
            _model = new PersonModel()
            {
                Name = "Common",
                Age = 5
            };
        }

        [Fact]
        public void ToJsonStringTest()
        {
            string json = _model.ToJsonString();

            Assert.NotNull(json);
            Assert.True(json.Length > 0);
        }

        [Fact]
        public void ToXmlStringTest()
        {
            string xml = _model.ToXmlString();

            Assert.NotNull(xml);
            Assert.True(xml.Length > 0);
        }
    }
}
