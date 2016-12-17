/**********************************************************************************************************************
 * 描述：
 *      序列化者工厂 测试。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年11月04日	 新建
 * 
 *********************************************************************************************************************/

using Wlitsoft.Framework.Common.Core;
using Wlitsoft.Framework.Common.Serialize;
using Xunit;

namespace Common.Test.Serialize
{
    /// <summary>
    /// 序列化者配置 测试。
    /// </summary>
    public class SerializerFactoryTest
    {
        [Fact]
        public void GetSerializerTest()
        {
            SerializerService sf = new SerializerService();
            ISerializer serializer = sf.GetSerializer(SerializeType.Json);

            Assert.NotNull(serializer);
            Assert.True(serializer.SerializeType == SerializeType.Json);
        }

        [Fact]
        public void SetSerializerTest()
        {
            //SerializerService sf = new SerializerService();
            //sf
            //    .SetSerializer(SerializeType.Xml, new XmlSerializer())
            //    .SetSerializer(SerializeType.Json, new JsonSerializer());
        }

        [Fact]
        public void GetJsonSerializerTest()
        {
            SerializerService sf = new SerializerService();
            ISerializer serializer = sf.GetJsonSerializer();

            Assert.NotNull(serializer);
            Assert.True(serializer.SerializeType == SerializeType.Json);
        }

        [Fact]
        public void GetXmlSerializerTest()
        {
            SerializerService sf = new SerializerService();
            ISerializer serializer = sf.GetXmlSerializer();

            Assert.NotNull(serializer);
            Assert.True(serializer.SerializeType == SerializeType.Xml);
        }
    }
}
