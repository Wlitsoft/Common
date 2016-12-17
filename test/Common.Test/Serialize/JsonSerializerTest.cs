/**********************************************************************************************************************
 * 描述：
 *      Json 序列化/反序列化 测试。
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
    /// Json 序列化/反序列化 测试。
    /// </summary>
    public class JsonSerializerTest
    {
        private readonly ISerializer _serializer;

        private readonly string _json = "{\"Age\":5,\"Name\":\"Common\"}";

        public JsonSerializerTest()
        {
            _serializer = new JsonSerializer();
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
