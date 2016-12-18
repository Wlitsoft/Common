/**********************************************************************************************************************
 * 描述：
 *      JsonNet Json 序列化/反序列化 测试。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年11月04日	 新建
 * 
 *********************************************************************************************************************/

using Common.JsonNet.JsonSerializer.Test.Model;
using Wlitsoft.Framework.Common.Core;
using Wlitsoft.Framework.Common.Serializer.JsonNet;
using Xunit;

namespace Common.JsonNet.JsonSerializer.Test
{
    /// <summary>
    /// JsonNet Json 序列化/反序列化 测试。
    /// </summary>
    public class JsonNetJsonSerializerTest
    {
        private readonly ISerializer _serializer;

        private readonly string _json = "{\"Age\":5,\"Name\":\"Common\"}";

        public JsonNetJsonSerializerTest()
        {
            _serializer = new JsonNetJsonSerializer();
        }

        [Fact]
        public void GetSerializeTypeTest()
        {
            Assert.True(_serializer.SerializeType == SerializeType.Json);
        }

        [Fact]
        public void SerializeTest()
        {
            PersonModel model = new PersonModel()
            {
                Name = "Common",
                Age = 5
            };

            string json = _serializer.Serialize(model);

            Assert.NotNull(json);
            Assert.True(json.Length > 0);
        }

        [Fact]
        public void DeserializeTest()
        {
            PersonModel model = (PersonModel)_serializer.Deserialize(typeof(PersonModel), _json);

            Assert.NotNull(model);
            Assert.Equal<string>("Common", model.Name);
            Assert.Equal<int>(5, model.Age);
        }

        [Fact]
        public void Deserialize_TTest()
        {
            PersonModel model = _serializer.Deserialize<PersonModel>(_json);

            Assert.NotNull(model);
            Assert.Equal<string>("Common", model.Name);
            Assert.Equal<int>(5, model.Age);
        }
    }
}
