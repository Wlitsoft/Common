/**********************************************************************************************************************
 * 描述：
 *      Xml 序列化/反序列化 测试。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年11月03日	 新建
 * 
 *********************************************************************************************************************/
using Common.Test.Model;
using Wlitsoft.Framework.Common.Core;
using Wlitsoft.Framework.Common.Serialize;
using Xunit;

namespace Common.Test.Serialize
{
    /// <summary>
    /// Xml 序列化/反序列化 测试。
    /// </summary>
    public class XmlSerializerTest
    {
        private readonly ISerializer _serializer;

        private readonly string _xml = @"<PersonModel>
                                            < Name > Common </ Name >
                                            < Age > 5 </ Age >
                                        </ PersonModel > ";

        public XmlSerializerTest()
        {
            _serializer = new XmlSerializer();
        }

        [Fact]
        public void GetSerializeTypeTest()
        {
            Assert.True(_serializer.SerializeType == SerializeType.Xml);
        }

        [Fact]
        public void SerializeTest()
        {
            PersonModel model = new PersonModel()
            {
                Name = "Common",
                Age = 5
            };

            string xml = _serializer.Serialize(model);

            Assert.NotNull(xml);
            Assert.True(xml.Length > 0);
        }

        [Fact]
        public void DeserializeTest()
        {

            PersonModel model = (PersonModel)_serializer.Deserialize(typeof(PersonModel), _xml);

            Assert.NotNull(model);
            Assert.Equal<string>("Common", model.Name);
            Assert.Equal<int>(5, model.Age);
        }

        [Fact]
        public void Deserialize_TTest()
        {
            PersonModel model = _serializer.Deserialize<PersonModel>(_xml);

            Assert.NotNull(model);
            Assert.Equal<string>("Common", model.Name);
            Assert.Equal<int>(5, model.Age);
        }
    }
}
